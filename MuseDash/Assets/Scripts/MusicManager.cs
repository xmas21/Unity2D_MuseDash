using UnityEngine;

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

    private AudioSource aud;

    private void Start()
    {
        aud = GameObject.Find("遊戲 BGM").GetComponent<AudioSource>();
        aud.clip = data.music;
        aud.Play();

        Invoke("StartMusic", data.timeWait);
    }

    private void StartMusic()
    {
        Instantiate(obj_Up, pos_Up);
    }
}
