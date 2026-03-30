using UnityEngine;

//when large, object grabbed it becomes kinematic, and other interactables become non kinematic or other way around. Object grabbed becomes non-kinematic
public class Sticky : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer objectRenderer;
    public bool isBlocked = false;
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered is interactable
        if (other.CompareTag("NotInteractable"))
        {
            //objectRenderer.material.color = Color.green;
            rb.isKinematic = true;
            isBlocked = true;
            //rb.constraints = RigidbodyConstraints.FreezeAll;

            /*
            Physics.IgnoreLayerCollision(
            LayerMask.NameToLayer("Sticky"),
            LayerMask.NameToLayer("Grabbable"),
            true
            );
            gameObject.layer = LayerMask.NameToLayer("Sticky");*/


        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NotInteractable"))
        {
            //objectRenderer.material.color = Color.red;
            rb.isKinematic = false;
            isBlocked = false;
        }
    }
}
