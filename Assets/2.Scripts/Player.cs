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
            Define.SfxType sfxType = Random.value < 0.5f ? Define.SfxType.Jump1 : Define.SfxType.Jump2;
            SoundManager.Instance.PlaySfx(sfxType);

            Effect effect = Instantiate(DataBaseManager.Instance.effect);
            effect.Active(transform.position);
        }

        if (transform.position.y < DataBaseManager.Instance.GameOverY)
        {
            Gamemanager.Instance.OnGameOver();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigd.velocity = Vector2.zero;
        anim.SetInteger("StateID", 0);

        CameraManager.Instance.OnFollow(transform.position);

        if(collision.transform.TryGetComponent(out Platform platform))
        {
            platform.OnLandingAnimation();
            if (landedPlatform == null)
            {
                landedPlatform = platform;
                return;
            }


            if (landedPlatform != platform) 
                ScoreManager.instance.AddBonus(DataBaseManager.Instance.BonusValue, transform.position);
            else 
                ScoreManager.instance.ResetBonus(transform.position);

            ScoreManager.instance.AddScore(platform.Score, platform.transform.position);

            landedPlatform = platform;

        }
    }
}
