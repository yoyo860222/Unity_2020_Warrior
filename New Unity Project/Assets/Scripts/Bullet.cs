using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子彈攻擊力
    /// </summary>
    public float attack;


    /// <summary>
    /// 沒有勾選 On Tigger 的 碰撞事件
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //如果碰撞物件有Boss腳本
        if (collision.gameObject.GetComponent<Boss>())
        {

            //對 Boss 呼叫 Damage(攻擊力)
            collision.gameObject.GetComponent<Boss>().Damage(attack);

        }

        Destroy(gameObject);
    }


}
