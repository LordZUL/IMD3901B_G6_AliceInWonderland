using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScaleOnButton : MonoBehaviour
{
    // how to get variable from another script: https://www.youtube.com/watch?v=2pCkInvkwZ0
    //trigger action very certain amount of time: https://www.youtube.com/watch?v=NFvmfoRnarY <- this is way too much for my brain to handle... ill just do it after demo -> if I have time qwq
    public float scale = 10f;
    public Transform playerTransform;
  
    //private ObjectGrabbable objectGrabbable;
    public NEWPlayerInteraction player;
    private NEWPlayerInteraction.SizeState lastSizeState;
    private Vector3 scaleSize = Vector3.one;
    private Vector3 originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
        if (player != null)
        {
            lastSizeState = player.currentSize;
        }
    }
    void Update()
    {
        // in interaction the handheld object gets destroyed, this function also runs on the objects around where it will scale up the objects if handheld object tag is 'grow'
        if (player == null)
        {
            return;
        }
        /*if (player.currentSize != lastSizeState)
        {
            ApplyScale(player.currentSize);
            lastSizeState = player.currentSize;
        }*/

        if (player.currentSize == lastSizeState) return;

        lastSizeState = player.currentSize;

        if (lastSizeState == NEWPlayerInteraction.SizeState.Small)
        {
            ScaleAroundPlayer(10f);
        }
        else if (lastSizeState == NEWPlayerInteraction.SizeState.Big)
        {
            ScaleAroundPlayer(0.1f);
        }
        else
        {
            transform.localScale = originalScale;
        }
        //float scaleFactor = 1f;
        /*
        if (player.currentSize == NEWPlayerInteraction.SizeState.Small)
        {
            // grab object scale; kinda want to try making player small XD
            //transform.localScale = transform.localScale + new Vector3(scale, scale, scale);
            SetScaleAroundPlayer(10f);
            //transform.localScale = Vector3.one * 10f;

        }
        else if (player.currentSize == NEWPlayerInteraction.SizeState.Big)
        {
            SetScaleAroundPlayer(0.1f);
            //transform.localScale = Vector3.one * 0.1f;

        }
        else
        {
            SetScaleAroundPlayer(1f);
            //transform.localScale = scaleSize;
        }*/
        //ScaleAroundPlayer(scaleFactor);
    }
    /*
    void ApplyScale(NEWPlayerInteraction.SizeState state)
    {
        if (state == NEWPlayerInteraction.SizeState.Small)
        {
            SetScaleAroundPlayer(10f);
        }
        else if (state == NEWPlayerInteraction.SizeState.Big)
        {
            SetScaleAroundPlayer(0.1f);
        }
        else
        {
            SetScaleAroundPlayer(1f);
        }
    }*/
    void ScaleAroundPlayer(float scaleFactor)
    {
        /*
        Vector3 offset = transform.position - playerTransform.position;

        transform.localScale *= scaleFactor;
        transform.position = playerTransform.position + offset * scaleFactor;*/
        Vector3 pivot = new Vector3(
         player.transform.position.x,
         0f,
         player.transform.position.z
     );

        Vector3 offset = transform.position - pivot;

        offset *= scaleFactor;

        transform.position = pivot + offset;

        transform.localScale *= scaleFactor;
    }
    void SetScaleAroundPlayer(float newScale)
    {
        float factor = newScale / transform.localScale.x;

        Vector3 offset = transform.position - player.transform.position;

        transform.localScale = Vector3.one * newScale;
        transform.position = player.transform.position + offset * factor;
    }
}
