using UnityEngine;
using UnityEngine.InputSystem;
// https://www.youtube.com/watch?v=2IhzPTS4av4
// only when player pick up uninteractables

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    private ObjectGrabbable objectGrabbable;
    NEWPlayerInteraction currentSize;
    NEWPlayerInteraction SizeState;

    private void update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            float pickupDistance = 2f;
            Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance);
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            // if hands empty, grab object
            if (objectGrabbable == null)
            {
                float pickupDistance = 5f;
                if (currentSize == SizeState.Big)
                {
                    pickupDistance = 100f;
                }
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
            //currently holding something
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }

            
        }*/
    }
}
