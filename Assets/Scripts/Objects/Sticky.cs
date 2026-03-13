using UnityEngine;

public class Sticky : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer objectRenderer;
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NotInteractable"))
        {
            //objectRenderer.material.color = Color.red;
            rb.isKinematic = false;
        }
    }
}
