using UnityEngine;
using UnityEngine.InputSystem;

public class NEWPlayerInteraction : MonoBehaviour
{
    // Interactions: hold e for more control during puzzel solve. Press E to have it locked. WASD, jump, climb (stamina)
    // Player vaulting: https://www.youtube.com/watch?v=9k7iBucBV7s -> basically done
    // Player grab (press): inventory?? Not sure if going to apply it for beta.. we'll see
    // Hold: grab items with finer control; perfect for the first rabbit puzzel! https://www.youtube.com/watch?v=2IhzPTS4av4&t=361s
    // Jumping advanced: not doing it right now https://www.youtube.com/watch?v=h2r3_KjChf4

    //public Camera playerCamera;
    public Transform playerCameraTransform;
    public LayerMask pickUpLayerMask;
    public Transform objectGrabPointTransform;
    public CrosshairUI crosshairUIScript;

    // to track if hands empty rn
    private ObjectGrabbable objectGrabbable;

    // to see what size is player -> small, average, giant
    public enum SizeState { Normal, Small, Big }
    public SizeState currentSize = SizeState.Normal;

    void Start()
    {
        // make heldobject defy gravityyy -> make object kinematic
        //heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            // if hands empty, grab object
            if (objectGrabbable == null)
            {
                float pickupDistance = 5f;
                // raycast will hit everything infront of player camera within distance and not on playerLayer
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
                {
                    //Debug.Log(raycastHit.transform);
                    // if object under ray has that script
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        //crosshairUIScript.SetInteract(true);
                        objectGrabbable.Grab(objectGrabPointTransform);


                    }
                }
            }
            else
            {
                //currently holding something
                objectGrabbable.Drop();
                objectGrabbable = null;
            }

            /*if (heldObject == null)
            {
                PickUpObject(hit.collider.gameObject);


            }*/

        }
        // if Q is pressed when currently holding something 
        if (Keyboard.current.qKey.wasPressedThisFrame && objectGrabbable != null)
        {
            //destoy object holding -> consume. If object tag == small, etc
            // if you ate the mushrooom -> object around you turn small
            if (objectGrabbable.gameObject.tag == "ConsumeGetBig")
            {
                if (currentSize == SizeState.Small)
                {
                    currentSize = SizeState.Normal;
                }
                else
                {
                    currentSize = SizeState.Big;
                }

            }
            else if (objectGrabbable.gameObject.tag == "ConsumeGetSmall")
            {
                if (currentSize == SizeState.Big)
                {
                    currentSize = SizeState.Normal;
                }
                else
                {
                    currentSize = SizeState.Small;
                }
            }

            Destroy(objectGrabbable.gameObject);
            objectGrabbable = null;
        }
        //crosshairUIScript.SetInteract(false);
    }
}
