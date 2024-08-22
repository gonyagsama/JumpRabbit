using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    private float JumpPower = 0;
    private Platform landedPlatform;

    private Rigidbody2D rigd;
    private Animator anim;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Init()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("StateID", 1);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            JumpPower += DataBaseManager.Instance.JumpPowerIncrease;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rigd.AddForce(Vector2.one * JumpPower);
            JumpPower = 0;

            anim.SetInteger("StateID", 2);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigd.velocity = Vector2.zero;
        anim.SetInteger("StateID", 0);

        CameraManager.Instance.OnFollow(transform.position);

        if(collision.transform.parent.TryGetComponent(out Platform platform))
        {
            //platform.OnLanding();
            ScoreManager.instance.AddScore(platform.Score, platform.transform.position);

            if (landedPlatform = platform) ScoreManager.instance.AddBonus(DataBaseManager.Instance.BonusValue, transform.position);
            else ScoreManager.instance.ResetBonus();

            landedPlatform = platform;

        }
    }
}
