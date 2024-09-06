using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D col;
    private Animation anim;
    [SerializeField] private int score;

    public float HalfSizeX => col.size.x * 0.5f;
    public int Score => score;

    private void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
        anim = GetComponent<Animation>();
    }
    public void Active(Vector2 pos, bool isFirstPlatform = false)
    {
        transform.position = pos;
        Debug.Log("Platform.position " + pos);

        if (isFirstPlatform == false && Random.value < DataBaseManager.Instance.itemSpawnPer)
        {
            Item item = Instantiate<Item>(DataBaseManager.Instance.baseItem);
            item.Active(transform.position, HalfSizeX);
        }
    }

    internal void OnLandingAnimation()
    {
        anim.Play();
    }
}
