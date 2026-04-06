using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
[RequireComponent(typeof(CharacterController))]
public class XRJump : MonoBehaviour
{
    public InputActionReference primaryButton; // Right controller primary (1 key in simulator)

    private CharacterController controller;
    public XREat VRplayer;
    private Vector3 velocity;

    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float gravityMultiplier = 2f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        primaryButton.action.Enable();
    }

    void Update()
    {
        // ===== GROUND CHECK =====
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // ===== JUMP =====
        if (primaryButton.action.WasPressedThisFrame() && controller.isGrounded && VRplayer.currentSize != XREat.SizeState.Big)
        {
            velocity.y = jumpForce;
            Debug.Log("JUMP!");
        }

        // ===== GRAVITY =====
        velocity.y += gravity * gravityMultiplier * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    /*public InputActionReference primaryButton;
    private CharacterController controller;

    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private LayerMask groundLayers;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        primaryButton.action.Enable();
    }

    void Update()
    {
        bool _isGrounded = IsGrounded();

        // reset downward velocity when grounded
        if (_isGrounded && movement.y < 0)
        {
            movement.y = -2f;
        }

        // jump
        if (primaryButton.action.WasPressedThisFrame() && _isGrounded)
        {
            Jump();
            Debug.Log("JUMP!");
        }

        // gravity
        movement.y += gravity * Time.deltaTime;

        controller.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(
            transform.position + Vector3.down * 0.9f,
            0.3f,
            groundLayers
        );
    }*/
}
