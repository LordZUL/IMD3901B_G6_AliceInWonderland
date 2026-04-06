using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticsUtility;

// code based on https://www.youtube.com/watch?v=Xf2eDfLxcB8
[RequireComponent(typeof(CharacterController))]
public class VRGravity : MonoBehaviour
{
    public ContinuousMoveProvider moveProvider;

    public CharacterController controller;
    private Vector3 velocity;
    public XREat VRplayer;

    //public float gravity = -9.81f;
    private float gravity = Physics.gravity.y;
    public float gravityMultiplier = 2f;
    //public float jumpForce = 15f;
    [SerializeField]  private float jumpHeight = 10f;
    [SerializeField] private LayerMask groundLayers;
    private Vector3 movement;
    //private bool wasGrounded;

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
        //bool _isGrounded = controller.isGrounded;
        bool _isGrounded = IsGrounded();
        /*if (!wasGrounded && grounded)
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
        */



        // ===== JUMP =====
        if (primaryButton.action.WasPressedThisFrame() && _isGrounded && VRplayer.currentSize != XREat.SizeState.Big)
        {
            Jump();
            //velocity.y = jumpForce;
            //Debug.Log("JUMP!");
        }

        movement.y += gravity * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);

        // ===== GRAVITY =====
        //velocity.y += gravity * gravityMultiplier * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);
        //wasGrounded = grounded;
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
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
