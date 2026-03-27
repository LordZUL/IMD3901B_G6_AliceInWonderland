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

    private R3ObjectGrabbable1 objectGrabbable;

    public enum SizeState { Normal, Small, Big }
    public SizeState currentSize = SizeState.Normal;

    private bool hasPaint = false;

    void Update()
    {
        float distance = (currentSize == SizeState.Big) ? bigPickupDistance : normalPickupDistance;

        RaycastHit hit;
        bool isLookingAtSomething = false;

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, distance))
        {
            GameObject hitObj = hit.transform.gameObject;

            // 🐰 RABBIT
            DialogueNPC3D npc = hitObj.GetComponent<DialogueNPC3D>();
            if (npc != null)
            {
                isLookingAtSomething = true;
                crosshairUIScript.SetInteract(true, hitObj);

                if (Keyboard.current.hKey.wasPressedThisFrame)
                {
                    npc.TryStartDialogue();
                }
            }
            // 🌹 ROSE
            else if (hitObj.GetComponent<Rose>() != null)
            {
                isLookingAtSomething = true;
                crosshairUIScript.SetInteract(true, hitObj);

                if (Keyboard.current.eKey.wasPressedThisFrame && hasPaint)
                {
                    Debug.Log("🌹 Painting Rose");
                    hitObj.GetComponent<Rose>().Paint();
                }
            }
            // 📦 GRABBABLE
            else if (((1 << hitObj.layer) & pickUpLayerMask) != 0)
            {
                if (hitObj.GetComponent<R3ObjectGrabbable1>() != null)
                {
                    isLookingAtSomething = true;
                    crosshairUIScript.SetInteract(true, hitObj);
                }
            }
        }

        // ❌ NOTHING HIT
        if (!isLookingAtSomething)
        {
            crosshairUIScript.SetInteract(false, null);
        }

        // 🖐️ GRAB / DROP (NOW ALWAYS RUNS)
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (objectGrabbable == null)
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, distance, pickUpLayerMask))
                {
                    if (hit.transform.TryGetComponent(out R3ObjectGrabbable1 grabbable))
                    {
                        objectGrabbable = grabbable;
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                if (objectGrabbable.CompareTag("PaintCan"))
                {
                    hasPaint = true;
                    Debug.Log("🎨 Got Paint!");
                    Destroy(objectGrabbable.gameObject);
                }
                else
                {
                    objectGrabbable.Drop();
                }

                objectGrabbable = null;
            }
        }
    }

}