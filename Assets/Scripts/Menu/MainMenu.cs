using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Room1_TeaParty");
    }
    public void How_To_Play_Button()
    {
        SceneManager.LoadScene("Tutorial_Room");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
