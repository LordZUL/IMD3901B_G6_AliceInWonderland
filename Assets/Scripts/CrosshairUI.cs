using UnityEngine;
using UnityEngine.UI;

public class CrosshairUI : MonoBehaviour
{
    public Image crosshairImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.pink;

    public GameObject interactionText;
    public GameObject rabbitInteractionText;
    public GameObject paintInteractionText;

    private bool hasInteractedOnce = false;

    void Start()
    {
        if (interactionText != null)
            interactionText.SetActive(false);

        if (rabbitInteractionText != null)
            rabbitInteractionText.SetActive(false);
    }

    public void SetInteract(bool isInteract, GameObject target)
    {
        // turn everything off first
        interactionText.SetActive(false);
        rabbitInteractionText.SetActive(false);
        paintInteractionText.SetActive(false);

        if (!isInteract || target == null) return;

        // 🐰 Rabbit
        if (target.GetComponent<DialogueNPC3D>() != null)
        {
            rabbitInteractionText.SetActive(true);
        }
        // 🌹 Rose
        else if (target.GetComponent<Rose>() != null)
        {
            paintInteractionText.SetActive(true);
        }
        // 📦 Default pickup
        else
        {
            interactionText.SetActive(true);
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
