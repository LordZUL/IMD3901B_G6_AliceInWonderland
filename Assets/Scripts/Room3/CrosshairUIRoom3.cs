using UnityEngine;
using UnityEngine.UI;

public class CrosshairUIRoom3 : MonoBehaviour
{
    public Image crosshairImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.pink;

    //public Renderer rend;
    public Color hoverColor = Color.white;
    //private Color originalColor = Color.black;
    public bool isSelected = false;

    public GameObject interactionText;
    public GameObject rabbitInteractionText;
    public GameObject paintInteractionText;
    public GameObject doorInteractionText;
    //public GameObject EatInteractableText;
    //public GameObject DropInteractableText;
    //public NEWPlayerInteraction playerSize;
    //private NEWPlayerInteraction.SizeState lastSizeState;
    //private GameObject lastTarget;

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
        else if ((target.GetComponent<ObjectGrabbable>() != null || target.CompareTag("PaintCan")) )
        {
            
            
            
            //var mats = rend.materials;
            //mats[1].SetColor("_Color", hoverColor);


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
