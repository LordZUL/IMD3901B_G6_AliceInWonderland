using UnityEngine;

public class playerAnimationInteraction : MonoBehaviour
{
    public PlayerController player;

    public void DisablePlayerMovement()
    {
        player.DisableMovement();
    }

    public void EnablePlayerMovement()
    {
        player.EnableMovement();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
