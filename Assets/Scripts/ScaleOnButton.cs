using Unity.VisualScripting.Antlr3.Runtime;
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
    public NEWPlayerInteraction player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        // in interaction the handheld object gets destroyed, this function also runs on the objects around where it will scale up the objects if handheld object tag is 'grow'
        if (player == null)
        {
            return;
        }
        if (player.currentSize == NEWPlayerInteraction.SizeState.Small)
        {
            // grab object scale; kinda want to try making player small XD
            //transform.localScale = transform.localScale + new Vector3(scale, scale, scale);
            transform.localScale = Vector3.one * 10f;

        }
        else if (player.currentSize == NEWPlayerInteraction.SizeState.Big)
        {
            transform.localScale = Vector3.one * 0.1f;

        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
}
