// to identify objects
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
    }
    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        //if hands not empty
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            //smoothness = lerp; curret position to target position
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }

    }
}
