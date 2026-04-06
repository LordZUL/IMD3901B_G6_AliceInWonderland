using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Room1_TeaParty_DESKTOP");
    }

    public void VR_Button()
    {
        SceneManager.LoadScene("VRMainMenu");
    }

    public void Desktop_Button()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
