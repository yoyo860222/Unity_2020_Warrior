using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [Header("目標物件")]
    [Tooltip("默認為角色")]
    public Transform target;

    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 3.5f;

    [Header("晃動區間"), Range(0, 1)]
    public float shakeInterval = 0.05f;

    [Header("晃動值"), Range(0, 5)]
    public float shakeValue = 0.5f;

    [Header("晃動次數"), Range(0, 5)]
    public int shakeCount = 3;


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

    public IEnumerator ShakeCamera()
    {

        for (int i = 0; i < shakeCount; i++)
        {
            transform.position += Vector3.up * shakeValue;
            yield return new WaitForSeconds(shakeInterval);
            transform.position -= Vector3.up * shakeValue;
            yield return new WaitForSeconds(shakeInterval);
        }
                        
    }
}
