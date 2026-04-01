using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using static UnityEditor.PlayerSettings;

public class ScaleOnXR : MonoBehaviour
{
    // how to get variable from another script: https://www.youtube.com/watch?v=2pCkInvkwZ0
    //trigger action very certain amount of time: https://www.youtube.com/watch?v=NFvmfoRnarY <- this is way too much for my brain to handle... ill just do it after demo -> if I have time qwq
    public float scale = 10f;
    //public Transform playerTransform;

    //private ObjectGrabbable objectGrabbable;
    public XREat VRplayer;
    private XREat.SizeState lastSizeState;
    public bool sizeBig = false;

    private Vector3 scaleSize = Vector3.one;
    private Vector3 originalScale;
    private Vector3 originalPosition;

    public ContinuousMoveProvider moveProvider;

    //set set sizes
    [SerializeField] private Vector3 smallScale = new Vector3(10f, 10f, 10f);
    [SerializeField] private Vector3 normalScale = Vector3.one;
    [SerializeField] private Vector3 bigScale = new Vector3(0.1f, 0.1f, 0.1f);
    //private bool isItBig;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
        //playerTransform = player.transform;
        if (VRplayer != null)
        {
            lastSizeState = VRplayer.currentSize;
        }
    }
    void Update()
    {
        // in interaction the handheld object gets destroyed, this function also runs on the objects around where it will scale up the objects if handheld object tag is 'grow'
        if (VRplayer == null)
        {
            return;
        }
        /*if (player.currentSize != lastSizeState)
        {
            ApplyScale(player.currentSize);
            lastSizeState = player.currentSize;
        }*/

        if (VRplayer.currentSize == lastSizeState) return;

        lastSizeState = VRplayer.currentSize;

        if (lastSizeState == XREat.SizeState.Small)
        {
            //ScaleAroundPlayer(10f);
            sizeBig = false;
            //moveProvider.moveSpeed = 25f;
            SetScale(smallScale);

            //transform.position = new Vector3(0f, 10f, 25f);
        }
        else if (lastSizeState == XREat.SizeState.Big)
        {
            sizeBig = true;
            //moveProvider.moveSpeed = 5f;

            //ScaleAroundPlayer(0.1f);
            SetScale(bigScale);
            //transform.position = new Vector3(0f, 2.25f, 2.43f);
        }
        else
        {
            sizeBig = false;
            //moveProvider.moveSpeed = 15f;

            //ScaleAroundPlayer(1f);
            SetScale(normalScale);
        }
        
    }
    
    void SetScale(Vector3 targetScale)
    {

        transform.localScale = targetScale;

    }
}
