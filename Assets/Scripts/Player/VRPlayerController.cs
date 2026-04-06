using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;

public class VRPlayerController : MonoBehaviour
{
    ContinuousMoveProvider moveProvider;

    private void Start()
    {
        moveProvider = GetComponentInChildren<ContinuousMoveProvider>(true);
        
        if (moveProvider != null)
        {
            Debug.Log("Found VR Move Provider");
            //moveProvider.enabled = false;
        }
    }

    public void DisableMovement()
    {
        if (moveProvider != null)
        {
            moveProvider.enabled = false;
        }
    }

    public void EnableMovement()
    {
        if (moveProvider != null)
        {
            moveProvider.enabled = true;
        }
    }
}