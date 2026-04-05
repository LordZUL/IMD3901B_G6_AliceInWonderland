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
    public GameObject doorInteractionText;
    public NEWPlayerInteraction playerSize;
    private NEWPlayerInteraction.SizeState lastSizeState;

    private bool hasInteractedOnce = false;

    void Start()
    {
        if (interactionText != null)
        {
            interactionText.SetActive(false);
        }

        if (rabbitInteractionText != null)
        {
            rabbitInteractionText.SetActive(false);
        }

        if (doorInteractionText != null)
        {
            doorInteractionText.SetActive(false);
        }
        if (playerSize != null)
        {
            lastSizeState = playerSize.currentSize;
        }
    }

    public void SetInteract(bool isInteract, GameObject target)
    {
        // turn everything off first
        interactionText.SetActive(false);
        rabbitInteractionText.SetActive(false);
        paintInteractionText.SetActive(false);
        doorInteractionText.SetActive(false);

        if (!isInteract || target == null)
        {
            return;
        }

        // Rabbit
        if (target.GetComponent<DialogueNPC3D>() != null)
        {
            rabbitInteractionText.SetActive(true);
        }
        // Rose
        else if (target.GetComponent<Rose>() != null)
        {
            paintInteractionText.SetActive(true);
        }
        // Door
        else if (target.CompareTag("Door"))
        {
            doorInteractionText.SetActive(true);
        }
        // Default pickup
        else if (target.GetComponent<ObjectGrabbable>() != null || target.CompareTag("PaintCan"))
        {
            //if (playerSize.currentSize == lastSizeState) return;

            lastSizeState = playerSize.currentSize;

            if (target.CompareTag("NotInteractable") && lastSizeState != NEWPlayerInteraction.SizeState.Big)
            {
                return;
            }
            
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

        if (doorInteractionText != null)
        {
            doorInteractionText.SetActive(false);
        }
    }
}
