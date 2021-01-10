using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("目標物件")]
    [Tooltip("默認為角色")]
    public Transform target;
    
    [Header("追蹤速度"),Range(0,100)]
    public float speed = 3.5f;
    

    private void Track()
    {
        Vector3 posA = target.position;
        Vector3 posB = transform.position;
        posA.z = -10;

        posB = Vector3.Lerp(posB, posA, 0.5f * speed*Time.deltaTime);
        transform.position = posB;
    }

    private void LateUpdate()
    {
        Track();

    }

}
