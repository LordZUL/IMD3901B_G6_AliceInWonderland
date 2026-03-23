using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image crosshairImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.pink;

    public GameObject interactionText;
    public GameObject rabbitInteractionText;

    private bool hasInteractedOnce = false;

    void Start()
    {
        if (interactionText != null)
            interactionText.SetActive(false);

        if (rabbitInteractionText != null)
            rabbitInteractionText.SetActive(false);
    }

    public void SetInteract(bool canInteract, GameObject target)
    {
        crosshairImage.color = canInteract ? interactColor : normalColor;

        if (hasInteractedOnce)
            return;

        if (canInteract && target != null)
        {
            if (target.CompareTag("Rabbit"))
            {
                if (rabbitInteractionText != null)
                    rabbitInteractionText.SetActive(true);

                if (interactionText != null)
                    interactionText.SetActive(false);
            }
            else
            {
                if (interactionText != null)
                    interactionText.SetActive(true);

                if (rabbitInteractionText != null)
                    rabbitInteractionText.SetActive(false);
            }
        }
        else
        {
            if (interactionText != null)
                interactionText.SetActive(false);

            if (rabbitInteractionText != null)
                rabbitInteractionText.SetActive(false);
        }
    }

    public void RegisterInteraction()
    {
        hasInteractedOnce = true;

        if (interactionText != null)
            interactionText.SetActive(false);

        if (rabbitInteractionText != null)
            rabbitInteractionText.SetActive(false);
    }
}
