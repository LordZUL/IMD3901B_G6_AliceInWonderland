using UnityEngine;
// only when player pick up uninteractables
public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    private void update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Physics.Raycast(transform.position);
        }
    }
}
