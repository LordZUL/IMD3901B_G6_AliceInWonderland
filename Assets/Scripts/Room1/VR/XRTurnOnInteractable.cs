using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRTurnOnInteractable : MonoBehaviour
{
    public XRGrabInteractable TurnPickableComponent;
    public ObjectGrabbable objectGrabbable;
    public ScaleOnXR size;
    //public NEWPlayerInteraction player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (size.sizeNormal == true)
        {
            gameObject.layer = LayerMask.NameToLayer("Ground");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
        objectGrabbable.enabled = false;
        bool canGrab = size.sizeBig && gameObject.CompareTag("NotInteractable");

        TurnPickableComponent.enabled = canGrab;
        /*if (objectGrabbable != null)
        {
            objectGrabbable.enabled = false;
        }*/
        /*
        if ((size.sizeBig == true) && (gameObject.tag == "NotInteractable"))
        {
            //gameObject.tag = "PickUp";
            TurnPickableComponent.enabled = true;

        }
        else
        {
            //gameObject.tag = "NotInteractable";
            TurnPickableComponent.enabled = false;
        }*/
    }
}
