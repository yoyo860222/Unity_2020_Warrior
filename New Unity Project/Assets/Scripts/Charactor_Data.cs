using UnityEngine;

public class Charactor_Data : MonoBehaviour
{
    [Header("移動速度")]
    [Range(0, 1000)]
    public float movespeed = 10.5f;

    [Header("跳躍高度")]
    [Range(0, 3000)]
    public int jumpheight = 100;

    [Header("是否站在地面上")]
    [Tooltip("是=true")]
    public bool ontheground = true;

    [Header("子彈")]
    [Tooltip("子彈剩餘")]
    [Range(0,25)]
    public int bullets;

    [Header("子彈生成點")]
    [Tooltip("子彈生成地點")]
    public Vector2 bulletfirelocation;

    [Header("子彈速度")]
    [Range(0,5000)]
    public int bulletspeed;

    [Header("開槍音效")]
    public ;



}
