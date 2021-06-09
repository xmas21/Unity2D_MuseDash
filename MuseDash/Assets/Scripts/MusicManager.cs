using UnityEngine;
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

    private AudioSource aud;

    private void Start()
    {
        aud = GameObject.Find("遊戲 BGM").GetComponent<AudioSource>();
        aud.clip = data.music;
        aud.Play();
        Physics.IgnoreLayerCollision(8, 8, true);

        Invoke("StartMusic", data.timeWait);
    }

    private void StartMusic()        // 開始遊戲
    {
        StartCoroutine(SpawnPoint());
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
                    GameObject OUp =  Instantiate(obj_Up, pos_Up.position, Quaternion.identity);
                    GameObject ODown = Instantiate(obj_Down, pos_Down.position, Quaternion.identity);
                    OUp.AddComponent<MusicPoint>().speed = data.speed;
                    ODown.AddComponent<MusicPoint>().speed = data.speed;
                    break;
            }

            yield return new WaitForSeconds(data.interval);
        }
    }
}
