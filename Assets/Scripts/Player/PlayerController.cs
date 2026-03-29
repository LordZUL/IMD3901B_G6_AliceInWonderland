using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
// Added Player Jumping: https://www.youtube.com/watch?v=cKPdSKBM4rs -> Player control

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float mouseSensitivity = 1f;
    public float jumpForce = 5f;

    public Transform cameraTransform;
    public Rigidbody rb;

    float xRotation = 0f;
    public bool canMove = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse look
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity;
        float mouseY = mouseDelta.y * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Jump
        if (Keyboard.current.spaceKey.wasPressedThisFrame && IsGrounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    void FixedUpdate()
    {
        // Movement (physics here!)
        if (!canMove)
        {
            // Stop horizontal movement but keep gravity
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            return;
        }
            Vector2 moveInput = new Vector2(
            (Keyboard.current.aKey.isPressed ? -1 : 0) + (Keyboard.current.dKey.isPressed ? 1 : 0),
            (Keyboard.current.sKey.isPressed ? -1 : 0) + (Keyboard.current.wKey.isPressed ? 1 : 0)
        );

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        Vector3 velocity = rb.linearVelocity;
        velocity.x = move.x * speed;
        velocity.z = move.z * speed;

        rb.linearVelocity = velocity; // KEEP Y velocity (gravity!)
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f);
    }


    // when animation plays
    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }
}
