using UnityEngine;
using UnityEngine.UI;

public class CrosshairUI : MonoBehaviour
{
    public Image crosshairImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.pink;

    public GameObject interactionText;

    private bool hasInteractedOnce = false;

    void Start()
    {
        if (interactionText != null)
            interactionText.SetActive(false);
    }

    public void SetInteract(bool canInteract)
    {
        crosshairImage.color = canInteract ? interactColor : normalColor;

        // Only show interaction text if the player hasn't interacted yet
        if (!hasInteractedOnce && interactionText != null)
        {
            interactionText.SetActive(canInteract);
        }
    }

    // Call this when the player actually interacts (presses the interact key)
    public void RegisterInteraction()
    {
        hasInteractedOnce = true;

        if (interactionText != null)
            interactionText.SetActive(false);
    }
}
