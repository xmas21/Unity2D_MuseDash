using UnityEngine;

// 敵人的腳本
public class MusicPoint : MonoBehaviour
{
    [Header("移動速度")]
    public float speed;

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Move();
    }

    private void Move() //移動
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) // 碰撞偵測
    {
        if (collision.tag == "刪除牆")
        {
            Destroy(gameObject);
        }
        else if (collision.tag == "主角攻擊碰撞")
        {
            player.AddScore();
            Destroy(gameObject);
        }
        else if (collision.tag == "主角")
        {
            player.Hit();
            Destroy(gameObject);
        }
    }
}
