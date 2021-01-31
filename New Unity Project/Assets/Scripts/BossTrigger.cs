using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [Header("Boss血條")]
    public GameObject Bosshp;
    [Header("Boss")]
    public GameObject Bossbody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name ==("Warrior"))
        {
            Bosshp.SetActive(true);
            Bossbody.SetActive(true);
        }
    }

}
