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

    /// <summary>
    /// 走路方式
    /// </summary>
    /// <param name="direction">走路方向</param>
    /// <param name="sound">走路聲音文字</param>
    /// <param name="speed">速度</param>
    /// 預設參數:選填式參數(有預設值，可不必設定)
    /// 選填式參數得要寫在(A,B,C,最後方)
    private void Move(string direction, string sound, int speed=50)
    {
        print("方向:"+direction);
        print("聲音文字:"+sound);
        print("速度:"+speed);
        print("走路音效");

    }

    private void Move()
    {
        print("移動");
    }

    private void Jump()
    {
        print("跳躍");
    }

    private void Shoot()
    {
        print("開槍");
    }

    private void Hurt(int damage =1)
    {
        print("傷害:"+ damage);
    }

    private void death(string objectname)
    {
        print("死亡:" + objectname);
    }


    #endregion

    #region 靜態屬性和方法
   
    private void Start()
    {
        Physics2D.gravity = new Vector2(0, -20);
        print("所有攝影機數量:" + Camera.allCamerasCount);
        print("2D重力大小:"+ Physics2D.gravity);
        
        //練習
        Application.OpenURL("https://unity.com/");
        Mathf.Floor(9.999f);
        Vector3.Distance(new Vector3(1,1,1) , new Vector3(22,22,22));
    }
    private void Update()
    {
        print("是否輸入任意鍵:" + Input.anyKeyDown);
        print("遊戲經過時間:" + Time.time);
        Input.GetKeyDown("space");
    }


    #endregion

}
