using UnityEngine;

//第一次套用腳本時執行，幫物品增加一堆東西
[RequireComponent(typeof(AudioSource),typeof(Rigidbody2D),typeof(CapsuleCollider2D))]
public class Boss : MonoBehaviour
{

    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;

    [Header("偵測範圍"), Range(0, 100)]
    public float rangeAtk = 10;

    [Header("攻擊力"), Range(0, 1000)]
    public float Attack = 10;

    [Header("血量"), Range(0, 5000)]
    public float hp = 2500;

    private Animator ani;
    private AudioSource aud;
    private Rigidbody2D rig;

    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        
    }
    
    public void Damage(float damage)
    {
        hp -= damage;
        ani.SetTrigger("受傷觸發");
    }



}
