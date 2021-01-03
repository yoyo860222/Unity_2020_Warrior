using UnityEngine;

public class Player : MonoBehaviour
{
#region 練習宣告

    [Header("移動速度"), Range(0, 1000)]
    public float movespeed = 10.5f;

    [Header("跳躍高度"), Range(0, 3000)]
    public int jumpheight = 100;

    [Header("是否站在地面上"), Tooltip("角色是否在地面上")]
    public bool isgrounded = true;

    [Header("子彈")]
    public GameObject bullet;

    [Header("子彈生成點"), Tooltip("子彈生成地點")]
    public Transform bulletspawn;

    [Header("子彈速度"), Range(0, 5000)]
    public int bulletspeed;

    [Header("開槍音效")]
    public AudioClip soundFire;
    
    [Header("血量"), Range(0,200)]
    public float health = 100;


    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

    #endregion

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    #region 方法

    private void Test()
    {
        print("hello");
    }

    private int Spawnhealth()
    {
        return 100;
    }

    private string Name()
    {
        return "Player_1";
    }

   


    #endregion

    public float X;

    public void Update()
    {
        X = Input.GetAxis("Horizontal");
        Move();
    }

    public void Move()
    {
        rig.velocity = new Vector2(X * movespeed, rig.velocity.y);
    }

    public void Jump()
    {

    }

    private void Shoot()
    {

    }

    private void Hurt(int damage = 1)
    {

    }

    private void death(string objectname)
    {

    }


}
