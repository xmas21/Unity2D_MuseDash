using UnityEngine;

[CreateAssetMenu(menuName ="Lobo/音樂資料",fileName ="音樂資料")]
public class MusicData : ScriptableObject
{
    [Header("音樂")]
    public AudioClip music;
    [Header("前面等待時間"),Range(0,10)]
    public float timeWait = 2f;
    [Header("節點間格時間"),Range(0,10)]
    public float interval = 1f;
    [Header("節點移動速度"),Range(0,1000)]
    public float speed = 300;

    [Header("音樂節點")]
    public PointType[] points;
}

public enum PointType
{
    none, up, down, both
}
