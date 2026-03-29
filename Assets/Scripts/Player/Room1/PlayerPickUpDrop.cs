using UnityEngine;
// only when player pick up uninteractables
public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    private void update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float pickupDistance = 2f;
            Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit, pickupDistance);
        }
    }
}
