using UnityEngine;
using UnityEngine.UI;
using System.Collections;    //引用 系統.集合 API  -協同程序需要

//第一次套用腳本時執行，幫物品增加一堆東西
[RequireComponent(typeof(AudioSource),typeof(Rigidbody2D),typeof(CapsuleCollider2D))]
public class Boss : MonoBehaviour
{

    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;

    [Header("偵測範圍"), Range(0, 100)]
    public float rangeAtk = 10;

    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 10;

    [Header("攻擊CD"), Range(0, 10)]
    public float attackCD = 1.5f;

    [Header("攻擊延遲給玩家的時間"), Range(0, 10)]
    public float attackDelay = 0.7f;


    [Header("血量"), Range(0, 5000)]
    public float hp = 2500;

    [Header("血量文字")]
    public Text textHp;

    [Header("血量圖片")]
    public Image imgHp;

    [Header("攻擊範圍位移")]
    public Vector3 offsetAttack;

    [Header("攻擊範圍大小")]
    public Vector3 sizeAttack;


    private Animator ani;
    private AudioSource aud;
    private Rigidbody2D rig;
    private float hpMax;
    private Player Player;
    private float timer;
    private CameraFollow cam;
    private bool isSecond;
    private ParticleSystem psSecond;


    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        hpMax = hp;
        Player = FindObjectOfType<Player>();
        cam = FindObjectOfType<CameraFollow>();
        psSecond = GameObject.Find("二階段攻擊特效").GetComponent<ParticleSystem>();

    }

    private void Update()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position + transform.right * offsetAttack.x + transform.up * offsetAttack.y, sizeAttack);
    }

    public void Damage(float damage)
    {
        hp -= damage;
        ani.SetTrigger("受傷觸發");

        textHp.text = hp.ToString();
        imgHp.fillAmount = hp / hpMax;

        if (hp <= hpMax * 0.8f) rangeAtk = 20;

        if (hp <= 0) Dead();

    }

    public void Move()
    {
        AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Hit") || info.IsName("Attack")) return;

        /** 判斷式移動寫法
        if (transform.position.x > Player.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        */

        //三元運算子寫法    布林值判斷 ? true的結果 : Fales的結果
        //浮點數y = X座標>玩家.X座標 ? 等於180 : 等於0
        float y = transform.position.x > Player.transform.position.x ? 180 : 0;
        transform.eulerAngles = new Vector3(0, y, 0);

        //浮點數 dis = 二維向量.距離測量(座標 , 玩家座標)
        float dis = Vector2.Distance(transform.position, Player.transform.position);
        if (dis > rangeAtk)
        {
            rig.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
        else
        {
            Attack();
        }
                
        //動畫.設定布林值("走路開關", 剛體.加速度.數值 > 0)
        ani.SetBool("走路開關", rig.velocity.magnitude > 0);
        // Magnitude = 將向量數值計算成 浮點數數值

        
    }

    private void Attack()
    {
        rig.velocity = Vector3.zero;

        if (timer < attackCD)
        {
            timer += Time.deltaTime;
        }
        else
        {
            ani.SetTrigger("攻擊觸發");
            timer = 0;
            StartCoroutine(DelaySendDamage());

        }
        
    }


    private IEnumerator DelaySendDamage()
    {
        //等待延遲時間
        yield return new WaitForSeconds(attackDelay);

        //碰撞物件 = 2D 物理.盒型覆蓋區域(中心點，尺寸，角度，圖層)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * offsetAttack.x + transform.up * offsetAttack.y, sizeAttack, 0, 1 << 9);

        //如果 碰到物件 存在 玩家.受傷(攻擊力)
        if (hit) Player.Hurt(attack);
        StartCoroutine(cam.ShakeCamera());

    }

    private void Dead()
    {
        hp = 0;
        textHp.text = 0.ToString();
        ani.SetBool("死亡開關", true);

        //取得原件<膠囊碰撞2D>().啟動 = 關閉
        GetComponent<CapsuleCollider2D>().enabled = false;
        rig.Sleep();
        rig.constraints = RigidbodyConstraints2D.FreezeAll;

        enabled = false;
    }

}
