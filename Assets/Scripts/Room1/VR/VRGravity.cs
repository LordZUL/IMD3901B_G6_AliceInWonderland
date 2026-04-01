using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class VRGravity : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 velocity;
    public XREat VRplayer;

    public float gravity = -9.81f;
    public float gravityMultiplier = 2f;
    public float jumpForce = 15f;

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
