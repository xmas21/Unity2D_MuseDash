using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [Header("背景流動的速度"), Range(0, 500)]
    public float speed;

    private void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}