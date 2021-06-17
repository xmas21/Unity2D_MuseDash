using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("跳躍高度"), Range(0, 30000)]
    public int jump = 100;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;
    [Header("最大血量"), Range(0, 2000)]
    public float hp_Max = 500;
    [Header("檢查地板的半徑"), Range(0.1f, 1f)]
    public float groundRadius = 0.5f;
    [Header("是否在地板上")]
    public bool isGround = false;
    [Header("檢查地板的位移")]
    public Vector3 groundOffset;
    [Header("跳躍音效")]
    public AudioClip soundJump;
    [Header("攻擊音效")]
    public AudioClip soundAttack;
    [Header("死亡畫面")]
    public GameObject dead_Panel;
    [Header("死亡區塊文字")]
    public Text title_Text;
    [Header("分數文字")]
    public Text Endscore_Text;

    private int score;            // 分數

    private Image hp_Bar;         // 血條
    private Text score_Text;      // 分數文字
    private GameObject jump_ps;   // 跳躍粒子
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    private MusicManager music;

    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();

        music = FindObjectOfType<MusicManager>();
        jump_ps = GameObject.Find("跑步效果");
        hp_Bar = GameObject.Find("血條上").GetComponent<Image>();
        score_Text = GameObject.Find("分數數值").GetComponent<Text>();

        hp = hp_Max;
    }

    private void Update()
    {
        Move();
        Attack();
        UpdateScore();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position + groundOffset, groundRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "結束牆")
        {
            Time.timeScale = 0;
            title_Text.text = "你獲勝了";
            Endscore_Text.text = score.ToString("F0");
            music.aud.Stop();
            dead_Panel.SetActive(true);
        }
    }

    public void AddScore()     // 加分
    {
        score += 100;
    }

    public void Hit()          // 受傷
    {
        hp -= 100;
        hp_Bar.fillAmount = hp / hp_Max;

        if (hp <= 0)
        {
            Dead();
        }
    }

    private void Move()        // 跳躍
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

    private void Attack()      // 攻擊
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            aud.PlayOneShot(soundAttack, 0.2f);
            ani.SetTrigger("攻擊觸發");
        }
    }

    private void Dead()        // 死亡
    {
        Time.timeScale = 0;
        title_Text.text = "你死亡了";
        Endscore_Text.text = score.ToString("F0");
        music.aud.Stop();
        dead_Panel.SetActive(true);
    }

    private void UpdateScore() // 更新分數
    {
        score_Text.text = score.ToString("F0");
    }
}