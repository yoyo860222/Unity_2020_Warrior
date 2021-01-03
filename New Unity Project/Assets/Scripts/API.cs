
using UnityEngine;

public class API : MonoBehaviour
{
  //修飾詞   類 別    欄位
    public Transform traA;
    public Transform tester;
    public Camera cam;
    public SpriteRenderer RenA;
    public GameObject ObjA;

    private void Start()
    {
        // 非靜態
        // 取得
        // 類別.屬性

        print("座標:"+ traA.position);
        print("顏色:"+ RenA.color);
        


        // 類別. 屬性
        tester.position = new Vector3(0, 2, 0);
        cam.backgroundColor = new Color(0.5f,0.2f,0.3f);
        RenA.flipX = true;
        ObjA.layer = 5;

        print("圖層:" + ObjA.layer);


    }

    private void Update()
    {
        //使用方法

        //欄位. 方法 (對,應,引,數)
        tester.Rotate(0, 0, 10);
        tester.Translate(0.1f, 0, 0, Space.World);
        
    }


}