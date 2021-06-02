using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("跳躍高度"), Range(0, 3000)]
    public int jump = 100;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;
    [Header("是否在地板上")]
    public bool isGround;
    [Header("跳躍音效")]
    public AudioClip sound_jump;
    [Header("攻擊音效")]
    public AudioClip sound_attack;

    private int score;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        Attack();
    }

    private void OnCollisionEnter(Collision col)
    {
        print(col.gameObject.name);
    }

    private void Jump()     // 跳躍
    {
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(new Vector2(0, jump));
                isGround = false;
                ani.SetTrigger("跳躍觸發");
            }
        }
    }

    private void Attack()   // 攻擊
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            ani.SetTrigger("攻擊觸發");
        }
    }

    private bool Dead()     // 死亡
    {
        return false;
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">收到的傷害</param>
    private void Hit(float damage)
    {

    }

    /// <summary>
    /// 加分
    /// </summary>
    /// <param name="add">要加的分數</param>
    private void AddScore(int score)
    {

    }

}