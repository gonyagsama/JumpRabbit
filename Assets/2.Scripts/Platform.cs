using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D col;
    private Animation anim;
    public int number;
    [SerializeField] private int score;

    public float HalfSizeX => col.size.x * 0.5f;
    public int Score => score;

    private void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
        anim = GetComponent<Animation>();
    }
    public void Active(Vector2 pos, int platformNum)
    {
        transform.position = pos;
        number = platformNum;

        if (platformNum == 1)
            return;

        if (Random.value < DataBaseManager.Instance.itemSpawnPer)
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
