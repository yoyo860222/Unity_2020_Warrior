
using UnityEngine;

public class APITest : MonoBehaviour
{
    void Start()
    {

        //靜態屬性 Static
        
        //取得
        //與法:類別名稱.靜態屬性
        print("隨機數值:"+ Random.value);
        print("Pi:"+ Mathf.PI);

        //設定
        //語法:類別名稱.靜態屬性 = 數值
        Cursor.visible = false;

        //靜態方法

        //使用
        //語法:類別名稱.靜態方法(對應引數)
        print("100~500範圍內隨機整數:"+ Random.Range(100, 500));
        print("-10~10隨機數絕對值:" + Mathf.Abs(Random.Range(-10, 10)));
    }

}
