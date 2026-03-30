using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class ScaleOnButton : MonoBehaviour
{
    // how to get variable from another script: https://www.youtube.com/watch?v=2pCkInvkwZ0
    //trigger action very certain amount of time: https://www.youtube.com/watch?v=NFvmfoRnarY <- this is way too much for my brain to handle... ill just do it after demo -> if I have time qwq
    public float scale = 10f;
    //public Transform playerTransform;
  
    //private ObjectGrabbable objectGrabbable;
    public NEWPlayerInteraction player;
    private NEWPlayerInteraction.SizeState lastSizeState;
    private Vector3 scaleSize = Vector3.one;
    private Vector3 originalScale;
    private Vector3 originalPosition;

    //set set sizes
    [SerializeField] private Vector3 smallScale = new Vector3(10f, 10f, 10f);
    [SerializeField] private Vector3 normalScale = Vector3.one;
    [SerializeField] private Vector3 bigScale = new Vector3(0.1f, 0.1f, 0.1f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
        //playerTransform = player.transform;
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
            //ScaleAroundPlayer(10f);
            SetScale(smallScale);
            //transform.position = new Vector3(0f, 10f, 25f);
        }
        else if (lastSizeState == NEWPlayerInteraction.SizeState.Big)
        {

            //ScaleAroundPlayer(0.1f);
            SetScale(bigScale);
        }
        else
        {
            //ScaleAroundPlayer(1f);
            SetScale(normalScale);
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

    //void ScaleAroundPlayer(float scaleFactor)
    void SetScale(Vector3 targetScale)
    {

        transform.localScale = targetScale;

        //transform.localScale = originalScale * scaleFactor;
        
    }

    void SnapPlayerToGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(player.transform.position + Vector3.up * 2f, Vector3.down, out hit, 10f))
        {
            Vector3 pos = player.transform.position;

            CapsuleCollider col = player.GetComponent<CapsuleCollider>();

            if (col != null)
            {
                pos.y = hit.point.y + col.height * 0.5f;
            }
            else
            {
                pos.y = hit.point.y + 1f; // fallback height
            }

            player.transform.position = pos;
        }
    }
}
