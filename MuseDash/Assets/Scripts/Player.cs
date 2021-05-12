using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("跳躍高度"), Range(0, 3000)]
    public int jump = 100;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;
    [Header("是否在地板上")]
    public bool isGround = false;

    private int score;
    private AudioClip sound1;
    private AudioClip sound2;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {

    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">收到的傷害</param>
    private void Hit(float damage)
    {

    }

    /// <summary>
    /// 死亡
    /// </summary>
    private bool Dead()
    {
        return false;
    }

    /// <summary>
    /// 加分
    /// </summary>
    /// <param name="add">要加的分數</param>
    private void AddScore(int add)
    {

    }

}

