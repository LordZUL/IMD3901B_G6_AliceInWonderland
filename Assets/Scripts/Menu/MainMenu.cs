using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Room1_TeaParty");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
