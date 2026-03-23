using UnityEngine;
using UnityEngine.InputSystem;

public class Room3Player : MonoBehaviour
{
    [Header("References")]
    public Transform playerCameraTransform;
    public LayerMask pickUpLayerMask;
    public Transform objectGrabPointTransform;
    public CrosshairUI crosshairUIScript;

    [Header("Settings")]
    public float normalPickupDistance = 5f;
    public float bigPickupDistance = 10f;

    private ObjectGrabbable objectGrabbable;

    public enum SizeState { Normal, Small, Big }
    public SizeState currentSize = SizeState.Normal;

    private RaycastHit hit;

    // ✅ NEW
    private bool hasPaint = false;

    void Update()
    {
        HandleRaycastUI();
        HandleGrabDrop();
        HandleUseItem();
    }

    void HandleRaycastUI()
    {
        float distance = (currentSize == SizeState.Big) ? bigPickupDistance : normalPickupDistance;

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, distance, pickUpLayerMask))
        {
            // ✅ GRABBABLE OBJECT
            if (hit.transform.GetComponent<ObjectGrabbable>() != null)
            {
                crosshairUIScript.SetInteract(true, hit.transform.gameObject);
                return;
            }

            // ✅ ROSE (paintable)
            if (hit.transform.GetComponent<Rose>() != null)
            {
                crosshairUIScript.SetInteract(true, hit.transform.gameObject);
                return;
            }
        }

        crosshairUIScript.SetInteract(false, null);
    }

    void HandleGrabDrop()
    {
        if (!Keyboard.current.eKey.wasPressedThisFrame) return;

        if (objectGrabbable == null)
        {
            TryGrab();
        }
        else
        {
            // ✅ CHECK IF PAINT CAN
            if (objectGrabbable.CompareTag("PaintCan"))
            {
                hasPaint = true;
                Destroy(objectGrabbable.gameObject);
            }
            else
            {
                objectGrabbable.Drop();
            }

            objectGrabbable = null;
        }
    }

    void TryGrab()
    {
        float distance = (currentSize == SizeState.Big) ? bigPickupDistance : normalPickupDistance;

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, distance, pickUpLayerMask))
        {
            if (hit.transform.TryGetComponent(out ObjectGrabbable grabbable))
            {
                objectGrabbable = grabbable;
                objectGrabbable.Grab(objectGrabPointTransform);
            }
        }
    }

    void HandleUseItem()
    {
        float distance = (currentSize == SizeState.Big) ? bigPickupDistance : normalPickupDistance;

        // ✅ PAINT ROSES WITHOUT HOLDING THEM
        if (Keyboard.current.eKey.wasPressedThisFrame && hasPaint)
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, distance))
            {
                if (hit.transform.TryGetComponent(out Rose rose))
                {
                    rose.Paint();
                    return;
                }
            }
        }

        // ✅ OPTIONAL: USING HELD ITEMS (Q)
        if (objectGrabbable == null) return;
        if (!Keyboard.current.qKey.wasPressedThisFrame) return;

        GameObject heldObject = objectGrabbable.gameObject;

        if (heldObject.CompareTag("PaintCan"))
        {
            hasPaint = true;
            Destroy(heldObject);
            objectGrabbable = null;
        }
    }
}