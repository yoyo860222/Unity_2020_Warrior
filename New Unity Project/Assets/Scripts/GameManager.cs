using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void GamePause()
    {
        Time.timeScale = 0;
    }
}
