using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("設定畫面")]
    public GameObject setPanel;
    [Header("設定畫面關掉按鈕")]
    public Button[] setBtn_Exit;

    private Button enterBtn;
    private Button exitBtn;
    private Button setBtn;

    private void Start()
    {
        enterBtn = GameObject.Find("按鈕 - 進入遊戲").GetComponent<Button>();
        exitBtn = GameObject.Find("按鈕 - 離開遊戲").GetComponent<Button>();
        setBtn = GameObject.Find("按鈕 - 設定").GetComponent<Button>();

        ClickBtn();
    }

    private void ClickBtn() // 點擊按鈕
    {
        enterBtn.onClick.AddListener(StartGame);
        exitBtn.onClick.AddListener(ExitGame);
        setBtn.onClick.AddListener(ShowSet);

        for (int i = 0; i < setBtn_Exit.Length; i++)
        {
            int index = i;
            setBtn_Exit[index].onClick.AddListener(NoShowSet);
        }
    }

    private void StartGame() // 開始遊戲
    {
        SceneManager.LoadScene("遊戲場景");
    }

    private void ExitGame() // 退出遊戲
    {
        Application.Quit();
    }

    private void ShowSet() // 顯示設定畫面
    {
        setPanel.SetActive(true);
    }

    private void NoShowSet() // 關閉設定畫面
    {
        setPanel.SetActive(false);
    }
}
