
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenescontrol : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("入場場景");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("SampleScene");

    }

    //離開遊戲
    public void ExitGame()
    {
        //應用程式.離開()
        Application.Quit();
    }


}
