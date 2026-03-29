using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFade : MonoBehaviour
{

    public Image fadeImage;

    void Start()
    {
        // When the scene loads, start fully black
        fadeImage.color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeFromBlack());
    }

    // Screen fades to black when player interacts with door and scene is changed
    public IEnumerator FadeToBlack()
    {
        float t = 0f;

        // 1f is the time it takes for the screen to fade completely to black
        while (t < 1f)
        {
            t += Time.deltaTime;

            fadeImage.color = new Color(0, 0, 0, t);

            yield return null;
        }
    }

    // Screen fades from black when new scene is loaded
    public IEnumerator FadeFromBlack()
    {
        float t = 1f;

        // 1f is the time it takes for the screen to fade completely to black
        while (t > 0f)
        {
            t -= Time.deltaTime;

            fadeImage.color = new Color(0, 0, 0, t);

            yield return null;
        }
    }
}
