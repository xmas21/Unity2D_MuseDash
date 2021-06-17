using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    [Header("音樂資料")]
    public MusicData data;
    [Header("生成物件 : 上方")]
    public GameObject obj_Up;
    [Header("生成物件 : 下方")]
    public GameObject obj_Down;
    [Header("生成位置 : 上方")]
    public Transform pos_Up;
    [Header("生成位置 : 下方")]
    public Transform pos_Down;
    [Header("再來一次按鈕")]
    public Button restart_Btn;
    [Header("回主選單按鈕")]
    public Button toMenu_Btn;
    [Header("設定區")]
    public GameObject set_Panel;
    [Header("繼續遊戲按鈕")]
    public Button resume_Btn;
    [Header("重新開始按鈕")]
    public Button regame_Btn;
    [Header("回主選單按鈕")]
    public Button menu_Btn;
    [Header("音樂撥放器")]
    public AudioSource aud;

    private Button set_Btn; // 設定按鈕

    private void Start()
    {
        set_Btn = GameObject.Find("暫停按鈕").GetComponent<Button>();
        aud = GameObject.Find("遊戲 BGM").GetComponent<AudioSource>();
        aud.clip = data.music;
        aud.Play();
        Physics.IgnoreLayerCollision(8, 8, true);

        Invoke("StartMusic", data.timeWait);

        ClickBtn();
    }

    private IEnumerator SpawnPoint() // 生節點
    {
        for (int i = 0; i < data.points.Length; i++)
        {
            switch (data.points[i])
            {
                case PointType.none:
                    break;
                case PointType.up:
                    GameObject tempUp = Instantiate(obj_Up, pos_Up.position, Quaternion.identity);
                    tempUp.AddComponent<MusicPoint>().speed = data.speed;
                    break;
                case PointType.down:
                    GameObject tempDown = Instantiate(obj_Down, pos_Down.position, Quaternion.identity);
                    tempDown.AddComponent<MusicPoint>().speed = data.speed;
                    break;
                case PointType.both:
                    GameObject OUp = Instantiate(obj_Up, pos_Up.position, Quaternion.identity);
                    GameObject ODown = Instantiate(obj_Down, pos_Down.position, Quaternion.identity);
                    OUp.AddComponent<MusicPoint>().speed = data.speed;
                    ODown.AddComponent<MusicPoint>().speed = data.speed;
                    break;
            }
            yield return new WaitForSeconds(data.interval);
        }
    }

    private void StartMusic()        // 開始遊戲
    {
        StartCoroutine(SpawnPoint());
    }

    private void ClickBtn()          // 點擊按鈕
    {
        restart_Btn.onClick.AddListener(Restart);
        regame_Btn.onClick.AddListener(Restart);
        toMenu_Btn.onClick.AddListener(ToMenu);
        menu_Btn.onClick.AddListener(ToMenu);
        set_Btn.onClick.AddListener(ShowSetPanel);
        resume_Btn.onClick.AddListener(ResumeGame);
    }

    private void Restart()           // 再來一局
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    private void ToMenu()            // 回主選單
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void ShowSetPanel()      // 顯示設定畫面
    {
        Time.timeScale = 0;
        aud.Stop();
        set_Panel.SetActive(true);
    }

    private void ResumeGame()        // 繼續遊戲
    {
        Time.timeScale = 1;
        aud.Play();
        set_Panel.SetActive(false);
    }
}
