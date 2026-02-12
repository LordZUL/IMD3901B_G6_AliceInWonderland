using UnityEngine;
using UnityEngine.InputSystem;

// Peak commands: E to grab, Q to throw
public class PlayerInteractions : MonoBehaviour
{
    // temporary: interactRange can be more and then it shows (E) pick up
    public float interactRange = 5f;
    public Camera playerCamera;
    public CrosshairUI crosshairUIScript;
    public Transform holdPoint;
    private GameObject heldObject;
    private Rigidbody heldObjectRb;

    // To throw object
    private bool isChargingThrow = false; // if player is holding E
    private float throwChargeTime = 0f; // the PEAK mechanic

    public float maxThrowForce = 20f; // limit of the throw distance
    public float chargeSpeed = 1f; // how fast meter fills -> should have UI showing throw meter too... not really important for escape room but fun

    // sound when throwing
    /*
    public AudioSource audioSource;
    public AudioClip throwSound;*/

    void Update()
    {
        //I think this is ray from camera
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        //bool isLookingAtInteractable = false;

        // if object in 5f, detect tag; if tag is pickup, ui is true and turns it pink, if e is pressed and held object is 0, pickup Object
        if (Physics.Raycast(ray, out hit, interactRange))
        {
            if (hit.collider.CompareTag("PickUp"))
            {
                crosshairUIScript.SetInteract(true);

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    if (heldObject == null)
                    {
                        PickUpObject(hit.collider.gameObject);
                    }

                }

                return;
            }
        }
        //if pickup tag not detected, curser turn white. 
        crosshairUIScript.SetInteract(false);

        if (heldObject != null)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                /*heldObject.transform.SetParent(null);

                // Re-enable physics
                heldObjectRb.isKinematic = false;
                heldObjectRb.useGravity = true;

                heldObject = null;
                heldObjectRb = null;*/
                isChargingThrow = true;
                throwChargeTime = 0f;
            }
            if (Keyboard.current.qKey.isPressed)
            {
                isChargingThrow = true;
                throwChargeTime += Time.deltaTime * chargeSpeed;

                // Clamp to max 1.0 (normalized)
                throwChargeTime = Mathf.Clamp01(throwChargeTime);
            }
            if (Keyboard.current.qKey.wasReleasedThisFrame)
            {
                ThrowHeldObject();
            }
            // if player eat the object... will edit the controls later feel like e is for eat and f is for interaction lol
            if (Keyboard.current.fKey.isPressed)
            {
                Destroy(heldObject);
            }
        }






    }
    void PickUpObject(GameObject obj)
    {
        heldObject = obj;
        heldObjectRb = obj.GetComponent<Rigidbody>();

        // Disable physics
        heldObjectRb.isKinematic = true;
        heldObjectRb.useGravity = false;

        // Parent to hold point
        heldObject.transform.SetParent(holdPoint);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.transform.localRotation = Quaternion.identity;
    }
    void ThrowHeldObject()
    {
        // Unparent object
        heldObject.transform.SetParent(null);

        // Re-enable physics
        heldObjectRb.isKinematic = false;
        heldObjectRb.useGravity = true;

        // Calculate force
        float finalForce = throwChargeTime * maxThrowForce;

        // Apply force in camera forward direction
        heldObjectRb.AddForce(playerCamera.transform.forward * finalForce, ForceMode.Impulse);
        /*
        if (audioSource != null && throwSound != null)
        {
            audioSource.PlayOneShot(throwSound);
        }*/

        // Reset states
        heldObject = null;
        heldObjectRb = null;
        isChargingThrow = false;
        throwChargeTime = 0f;
    }
}
