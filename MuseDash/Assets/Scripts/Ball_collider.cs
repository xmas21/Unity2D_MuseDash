using UnityEngine;

public class Ball_collider : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "地板")
        {
            player.isGround = true;
        }
    }
}
