﻿using UnityEngine;

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
        ani = GetComponent<Animator>();
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
    }
    

    public void Move()
    {
        rig.velocity = new Vector2(X * movespeed, rig.velocity.y);
       
        //如果 按下 D 或 右箭頭
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
	    {
           transform.localEulerAngles = Vector3.zero;
            print("按D");
        }
        //左邊
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            print("按A");
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
            isgrounded = false;
        }
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
