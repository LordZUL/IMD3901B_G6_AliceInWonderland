using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class VRGravity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private CharacterController controller;
    private Vector3 velocity;

    public float gravity = -9.81f;
    public float gravityMultiplier = 2f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * gravityMultiplier * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
