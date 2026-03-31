// to identify objects
using NUnit.Framework.Internal;
using UnityEngine;
//to activate and deactive componentshttps://www.youtube.com/watch?v=ELhWPrxxks8
public class ObjectGrabbable : MonoBehaviour
{

    public NEWPlayerInteraction player;
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    public bool isHeld { get; private set; }

    public Spawner spawner;

    private void Awake()
    {
        if (player == null)
        {
            player = FindFirstObjectByType<NEWPlayerInteraction>();
        }
        objectRigidbody = GetComponent<Rigidbody>();
    }

    //object picked up become non-kinematic
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
        isHeld = true;
        objectRigidbody.isKinematic = false;
        objectRigidbody.useGravity = false;

        objectRigidbody.linearVelocity = Vector3.zero;
        objectRigidbody.angularVelocity = Vector3.zero;
        //objectRigidbody.isKinematic = false;


    }
    public void Drop()
    {
        this.objectGrabPointTransform = null;
        isHeld = false;
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

    public void OnConsumed()
    {
        if (spawner != null && gameObject.tag == "Carrot")
        {
            spawner.OnCarrotDestroyed();
        }
        
    }


}
