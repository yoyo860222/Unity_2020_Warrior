
using UnityEngine;

public class Car : MonoBehaviour
{
    // 數值
    [Header("汽車數值")]
    [Tooltip("單位:cm")]
    public int height = 150;
    [Tooltip("單位:t")]
    public float weight = 3.5f;
    [Range(1,10)]
    public int tootsound = 5;
    [Header("汽車品牌")]
    public string carbrand = "BMW";
    [Header("汽車配件")]
    public bool topwindow = true;

    // 顏色
    public Color charactorcolor = new Color(1.5f, 0.2f, 0.3f);

    //向量,座標
    public Vector2 spawn;
    [Header("血量與數據")]
    public Vector3 health = new Vector3(5, 5, 5);


    //圖片與音效
    [Header("圖片與音效")]
    public Sprite picture;
    public AudioClip sound;

    //物件與元件
    [Header("工具")]
    public Transform trans;
    public Camera cam;
    public GameObject ammo;
    public GameObject objA;
    

}
