using UnityEngine;

//when 
public class Sticky : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer objectRenderer;
    private ObjectGrabbable grabbable;

    void Start()
    {
        //objectRenderer = GetComponent<Renderer>();

        rb = GetComponent<Rigidbody>();
        grabbable = GetComponent<ObjectGrabbable>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        // Check if the object that entered is interactable
        if (grabbable != null && !grabbable.isHeld && other.collider.CompareTag("NotInteractable"))
        {
            //objectRenderer.material.color = Color.green;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            //rb.useGravity = false;
        }
    }
    /*
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NotInteractable"))
        {
            //objectRenderer.material.color = Color.red;
            rb.isKinematic = false;
        }
    }*/
}
