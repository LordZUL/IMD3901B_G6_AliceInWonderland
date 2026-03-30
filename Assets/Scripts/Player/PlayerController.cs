using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
// Added Player Jumping: https://www.youtube.com/watch?v=cKPdSKBM4rs -> Player control
//Player control playlist: https://youtube.com/playlist?list=PLBcfp6HMOJwzDcdCzoAx3jJKm7sIcBXJZ&si=snXGOItQbdXOjrj0

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    private Vector2 _input;
    private CharacterController _characterController;

    // in the youtube tutorial, he used direction of keyboard to determine the direction where camera is facing. To make it so it follows mouse movement I made following changes
    private Vector3 _direction;

    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private Transform cameraTransform;
    private float xRotation = 0f;


    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;
    [SerializeField] private float speed;

    // Gravity variables:
    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    //private float _velocity;
    private Vector3 _velocity;

    //Jumping 
    [SerializeField] private float jumpPower;
    private Rigidbody rb;
    LedgeGrabbing ledge;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        
        ApplyMovement();


    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -1f; // keeps player grounded
        }
        else
        {
            _velocity.y += _gravity * gravityMultiplier * Time.deltaTime;
        }

        
    }
    //Jump
    private void ApplyRotation()
    {
        
        
        // ===== MOUSE LOOK =====
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity;
        float mouseY = mouseDelta.y * mouseSensitivity;

        // vertical camera rotation (up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // horizontal player rotation (left/right)
        transform.Rotate(Vector3.up * mouseX);
        
       

        
        //return angle in radius * Rad2Deg to get degree
        /*
        if (_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        //smooth out turn
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);*/
        

    }

    private void ApplyMovement()
    {
        // ===== MOVEMENT =====
        Vector3 move = transform.right * _direction.x + transform.forward * _direction.z;
        //_characterController.Move(move * speed * Time.deltaTime);
        // combine horizontal + vertical properly
        Vector3 finalMove = move * speed + _velocity;

        _characterController.Move(finalMove * Time.deltaTime);

    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!canMove) return;
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!_characterController.isGrounded) return;

        _velocity.y = jumpPower;
        /*
        if (ledge.hanging)
        {
            rb.useGravity = true;
            ledge.hanging = false;
            _velocity.y = jumpPower;
        }
        else
        {
            _velocity.y = jumpPower;
        }*/
        

    }
    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }
    /*public float speed = 8f;
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
        return Physics.Raycast(transform.position, Vector3.down, 2f);
    }


    // when animation plays
    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }*/
}
