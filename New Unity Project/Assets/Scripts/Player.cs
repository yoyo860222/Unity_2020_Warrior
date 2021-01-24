using UnityEngine;
using UnityEngine.UI;

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

    [Header("子彈傷害"), Range(0, 5000)]
    public int damageBullet = 50;

    [Header("開槍音效")]
    public AudioClip soundFire;

    [Header("得到鑰匙")]
    public AudioClip soundKey;

    [Header("血量"), Range(0, 200)]
    public float health = 100;

    [Header("碰撞判斷位置")]
    public Vector3 location;

    [Header("碰撞判斷範圍")]
    public float range;

    
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

    #endregion

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        hpMax = health;
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
        Jump();
        Shoot();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,1,0.4f);
        Gizmos.DrawSphere(transform.position +location ,range);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Iron_Key")
        {
            Destroy(collision.gameObject);
            aud.PlayOneShot(soundKey, 1.5f);
        }
    }

    public void Move()
    {
        rig.velocity = new Vector2(X * movespeed, rig.velocity.y);
       
        //如果 按下 D 或 右箭頭
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
	    {
           transform.localEulerAngles = Vector3.zero;
        }
        //左邊
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        //Animator 的 設定布林值 run_switch , 判斷X不等於0
        // X 等於 0 時 回傳 false, X 不等於 0 時 回傳 true 
        ani.SetBool("run_switch", X != 0);
       

    }
        
    public void Jump()
    {
        if (isgrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0, jumpheight));
            ani.SetTrigger("Jumping");
        }

        Collider2D hit = Physics2D.OverlapCircle(transform.position + location, range, 1 << 8);

        if (hit)
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }

        ani.SetFloat("jump_float", rig.velocity.y);
        ani.SetBool("On_the_ground", isgrounded);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            //Mouse0 = 滑鼠左鍵
            //Mouse1 = 滑鼠右鍵
            //Mouse2 = 滑鼠中鍵
        {
            aud.PlayOneShot(soundFire, Random.Range(1.2f, 3.0f));
            //遊戲物件 暫存變數 生成物件
            GameObject temp = Instantiate(bullet,bulletspawn.position,bulletspawn.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(bulletspawn.right *bulletspeed + bulletspawn.up * 150);

            temp.AddComponent<Bullet>().attack = damageBullet;
        }

    }

    [Header("血量文字")]
    public Text textHp;
    
    [Header("血量圖片")]
    public Image imgHp;

    private float hpMax;

    public void Hurt(float getDamage)
    {
        health -= getDamage;
        textHp.text = health.ToString();
        imgHp.fillAmount = health / hpMax;

        if (health <=0)
        {
            Death();
        }
    }

    private void Death()
    {
        health = 0;
        textHp.text = 0.ToString();
        ani.SetBool("die_switch", true);
        enabled = false;
        transform.Find("US").gameObject.SetActive(false);

    }


}
