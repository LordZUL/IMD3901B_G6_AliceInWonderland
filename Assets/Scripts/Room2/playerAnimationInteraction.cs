using UnityEngine;
// so when animation plays player dont move
public class playerAnimationInteraction : MonoBehaviour
{
    public PlayerController player;
    public VRPlayerController VRplayer;

    public void DisablePlayerMovement()
    {
        player.DisableMovement();
        VRplayer.DisableMovement();
    }

    public void EnablePlayerMovement()
    {
        player.EnableMovement();
        VRplayer.EnableMovement();
    }
}
