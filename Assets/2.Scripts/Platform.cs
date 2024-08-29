using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D col;
    [SerializeField] private int score;

    public float HalfSizeX => col.size.x * 0.5f;
    public int Score =>score;

    private void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
    }
    public void Active(Vector2 pos)
    {
        transform.position = pos;

        if(Random.value < DataBaseManager.Instance.itemSpawnPer)
        {
        Item item = Instantiate<Item>(DataBaseManager.Instance.baseItem);
        item.Active(transform.position, HalfSizeX);
        }
    }

    internal void OnLanding()
    {
        ScoreManager.instance.AddScore(score, transform.position);
    }
}
