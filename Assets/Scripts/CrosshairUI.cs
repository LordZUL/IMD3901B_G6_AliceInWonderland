using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrosshairUI : MonoBehaviour
{
    public Image crosshairImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.pink;

    public GameObject interactionText; 

    public void SetInteract(bool canInteract)
    {
        crosshairImage.color = canInteract ? interactColor : normalColor;

        if (interactionText != null)
        {
            interactionText.SetActive(canInteract);
        }
    }
}
