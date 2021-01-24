using UnityEngine;
using UnityEngine.UI;

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

    [Header("血量"), Range(0, 5000)]
    public float hp = 2500;

    [Header("血量文字")]
    public Text textHp;

    [Header("血量圖片")]
    public Image imgHp;

    private Animator ani;
    private AudioSource aud;
    private Rigidbody2D rig;
    private float hpMax;
    private Player Player;


    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        Player = FindObjectOfType<Player>();

    }

    private void Update()
    {
        Move();

    }
    
    public void Damage(float damage)
    {
        hp -= damage;
        ani.SetTrigger("受傷觸發");
        

    }

    public void Move()
    {
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
        ani.SetTrigger("攻擊觸發");
    }


}
