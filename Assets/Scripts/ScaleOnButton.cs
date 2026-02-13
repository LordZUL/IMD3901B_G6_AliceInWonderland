using UnityEngine;
using UnityEngine.InputSystem;

public class ScaleOnButton : MonoBehaviour
{
    // how to get variable from another script: https://www.youtube.com/watch?v=2pCkInvkwZ0
    //trigger action very certain amount of time: https://www.youtube.com/watch?v=NFvmfoRnarY <- this is way too much for my brain to handle... ill just do it after demo -> if I have time qwq
    public float scale = 10f;
    //public int status;
    //public PlayerInteractions playerInteraction;
    //public Test test;
    private ObjectGrabbable objectGrabbable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        // in interaction the handheld object gets destroyed, this function also runs on the objects around where it will scale up the objects if handheld object tag is 'grow'
        if (objectGrabbable.tag == "ConsumeGetSmall")
        {
            // grab object scale; kinda want to try making player small XD
            transform.localScale = transform.localScale + new Vector3(scale, scale, scale);
            
        }
        if (objectGrabbable.gameObject.tag == "ConsumeGetBig")
        {
            scale = 50f;

            // grab object scale; kinda want to try making player small XD
            //transform.localScale = transform.localScale - new Vector3(scale, scale, scale);
            Vector3 newScale = transform.localScale - new Vector3(scale, scale, scale);
            
            //clamp -> I asked chatGPT and it gave me clamp solution
            
            newScale = new Vector3(
            Mathf.Max(newScale.x, 0.01f),
            Mathf.Max(newScale.y, 0.01f),
            Mathf.Max(newScale.z, 0.01f));

            transform.localScale = newScale;

        }
    }
}
