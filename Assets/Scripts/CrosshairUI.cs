using UnityEngine;
using UnityEngine.UI;

public class CrosshairUI : MonoBehaviour
{
    public Image crosshairImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.pink;

    //public Renderer rend;
    public Color hoverColor = Color.white;
    //private Color originalColor = Color.black;
    //public bool isSelected = false;

    public GameObject interactionText;
    public GameObject rabbitInteractionText;
    public GameObject paintInteractionText;
    public GameObject doorInteractionText;
    public GameObject grabEatText;
    public GameObject dropText;
    public NEWPlayerInteraction playerSize;
    private NEWPlayerInteraction.SizeState lastSizeState;
    private GameObject lastTarget;

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
        if (grabEatText != null)
        {
            grabEatText.SetActive(false);
        }
        if (dropText != null)
        {
            dropText.SetActive(false);
        }
        if (playerSize != null)
        {
            lastSizeState = playerSize.currentSize;
        }
        //if (rend == null)
        //rend = GetComponent<Renderer>();

        //originalColor = rend.material.GetColor("_Color");
    }

    public void SetInteract(bool isInteract, GameObject target)
    {
        // turn everything off first
        interactionText.SetActive(false);
        rabbitInteractionText.SetActive(false);
        paintInteractionText.SetActive(false);
        doorInteractionText.SetActive(false);

        ObjectGrabbable heldObj = playerSize.GetHeldObject();

        if (heldObj != null)
        {
            // Always show drop text when holding something
            dropText.SetActive(true);

            // If it's carrot or mushroom, also show eat text
            if (heldObj.CompareTag("Carrot") || heldObj.CompareTag("Mushroom"))
            {
                grabEatText.SetActive(true);
            }
            else
            {
                grabEatText.SetActive(false);
            }
        }
        else
        {
            dropText.SetActive(false);
            grabEatText.SetActive(false);
        }

        if (!isInteract || target == null)
        {
            if (lastTarget != null)
            {
                ResetOutline(lastTarget);
                lastTarget = null;
            }

            return;
        }
        if (lastTarget != null && lastTarget != target)
        {
            ResetOutline(lastTarget);
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
            lastSizeState = playerSize.currentSize;

            if (target.CompareTag("NotInteractable") && lastSizeState != NEWPlayerInteraction.SizeState.Big)
            {
                return;
            }
            //if (playerSize.currentSize == lastSizeState) return;
            Renderer targetRenderer = target.GetComponentInChildren<Renderer>();

            if (targetRenderer != null && targetRenderer.materials.Length > 1)
            {
                var mats = targetRenderer.materials;
                mats[1].SetColor("_Color", hoverColor);
            }
            lastTarget = target;


            //var mats = rend.materials;
            //mats[1].SetColor("_Color", hoverColor);


            interactionText.SetActive(true);
        }
    }

    void ResetOutline(GameObject obj)
    {
        Renderer r = obj.GetComponentInChildren<Renderer>();

        if (r != null && r.materials.Length > 1)
        {
            var mats = r.materials;
            mats[1].SetColor("_Color", Color.black); // or your default
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
