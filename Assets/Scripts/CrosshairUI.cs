using UnityEngine;
using UnityEngine.UI;

public class CrosshairUI : MonoBehaviour
{
    public Image crosshairImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.pink;

    public GameObject interactionText;

    void Start()
    {
        if (interactionText != null)
            interactionText.SetActive(false); // force it off at start
    }

    public void SetInteract(bool canInteract)
    {
        crosshairImage.color = canInteract ? interactColor : normalColor;

        if (interactionText != null)
            interactionText.SetActive(canInteract);
    }
}
