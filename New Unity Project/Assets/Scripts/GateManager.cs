using UnityEngine;

public class GateManager : MonoBehaviour
{
    [Header("傳送門的另一端")]
    public Transform otherTeleport;

    private bool playerIn;
    private Transform player;

    private void Teleport()
    {
        if (playerIn && Input.GetKeyDown(KeyCode.W))
        {
            player.position = otherTeleport.position = Vector3.up * 1.5f;
        }
    }

    private void Awake()
    {
        player = GameObject.Find("Warrior").transform;
    }

    private void Update()
    {
        Teleport();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Warrior") playerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Warrior") playerIn = false;
    }
}
