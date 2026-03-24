// to identify objects
using NUnit.Framework.Internal;
using UnityEngine;
//to activate and deactive componentshttps://www.youtube.com/watch?v=ELhWPrxxks8
public class objectGrabbable : MonoBehaviour
{

    public Room3Player player;
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        /*
        Debug.Log(test.currentSize);
        if ( gameObject.tag == "NotInteractable" && test.currentSize != Test.SizeState.Big)
        {
            return;
        }
        else
        {
            this.objectGrabPointTransform = objectGrabPointTransform;
            objectRigidbody.useGravity = false;
        }*/

        // set gravity to false
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
