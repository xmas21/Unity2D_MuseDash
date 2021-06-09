using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("跳躍高度"), Range(0, 30000)]
    public int jump = 100;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;
    [Header("是否在地板上")]
    public bool isGround = false;
    [Header("檢查地板的半徑"), Range(0.1f, 1f)]
    public float groundRadius = 0.5f;
    [Header("檢查地板的位移")]
    public Vector3 groundOffset;
    [Header("跳躍音效")]
    public AudioClip soundJump;
    [Header("攻擊音效")]
    public AudioClip soundAttack;

    private int score; // 分數
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    private GameObject jump_ps;

    private void Start()
    {
        // 動畫元件 = 取得元件<泛型>()；
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();

        jump_ps = GameObject.Find("跑步效果");
    }

    private void Update()
    {
        Move();
        Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position + groundOffset, groundRadius);
    }

    private void Move() // 跳躍
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position + groundOffset, groundRadius, 1 << 10);

        if (col && col.name == "地板")
        {
            isGround = true;
            jump_ps.SetActive(true);
        }
        else
        {
            isGround = false;
            jump_ps.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W) && isGround)
        {
            ani.SetTrigger("跳躍觸發");
            aud.PlayOneShot(soundJump, 0.2f);
            jump_ps.SetActive(false);
            rig.AddForce(new Vector2(0, jump));
        }
        else if (Input.GetKeyDown(KeyCode.W) && !isGround)
        {
            ani.SetTrigger("跳躍觸發");
            aud.PlayOneShot(soundJump, 0.2f);
            transform.position = new Vector3(-6, 2.2f, 0);
            rig.velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.S) && !isGround)
        {
            rig.velocity = Vector2.zero;
            transform.position = new Vector3(-6, -2.6f, 0);
        }
    }

    private void Attack() // 攻擊
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            aud.PlayOneShot(soundAttack, 0.2f);
            ani.SetTrigger("攻擊觸發");
        }
    }

    private bool Dead() // 死亡
    {
        return false;
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">傷害</param>
    private void Hit(float damage)
    {

    }

    /// <summary>
    /// 加分
    /// </summary>
    /// <param name="add">分數</param>
    private void AddScore(int score)
    {

    }
}