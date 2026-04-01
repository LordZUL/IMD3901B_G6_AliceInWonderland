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
        objectGrabbable.enabled = false;
        bool canGrab = size.sizeBig && gameObject.CompareTag("NotInteractable");

        TurnPickableComponent.enabled = canGrab;
        if (objectGrabbable != null)
        {
            objectGrabbable.enabled = false;
        }
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
