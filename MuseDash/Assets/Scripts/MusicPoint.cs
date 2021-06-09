using UnityEngine;

public class MusicPoint : MonoBehaviour
{
    [Header("移動速度")]
    public float speed;

    private void Update()
    {
        Move();
    }

    private void Move() //移動
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

}
