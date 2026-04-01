using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;


[RequireComponent(typeof(CharacterController))]
public class VRGravity : MonoBehaviour
{
    public ContinuousMoveProvider moveProvider;

    private CharacterController controller;
    private Vector3 velocity;
    public XREat VRplayer;

    public float gravity = -9.81f;
    public float gravityMultiplier = 2f;
    public float jumpForce = 15f;
    private bool wasGrounded;

    public InputActionReference primaryButton; // RIGHT primary

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
        bool grounded = controller.isGrounded;
        if (!wasGrounded && grounded)
        {
            // player JUST landed
            velocity.y = -2f;

           
            moveProvider.moveSpeed = 0f;
        }

        // ===== GROUND CHECK =====
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (grounded && moveProvider.moveSpeed == 0f)
        {
            moveProvider.moveSpeed = 15f; 
        }



        // ===== JUMP =====
        if (primaryButton.action.WasPressedThisFrame() && grounded && VRplayer.currentSize != XREat.SizeState.Big)
        {
            velocity.y = jumpForce;
            Debug.Log("JUMP!");
        }

        // ===== GRAVITY =====
        velocity.y += gravity * gravityMultiplier * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        wasGrounded = grounded;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*private CharacterController controller;
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
    }*/
}
