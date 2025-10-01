using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class CharacterInputController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float lookSensitivity = 1f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Events")]
    public UnityEvent OnJump;
    public UnityEvent OnAttack;
    public UnityEvent OnInteract;

    // Components
    private CharacterController controller;
    private PlayerInput playerInput;
    private Camera playerCamera;

    // Input Actions
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction interactAction;
    private InputAction attackAction;

    // Movement Variables
    private Vector2 movementInput;
    private Vector2 lookInput;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isSprinting;

    // Rotation
    private float xRotation = 0f;

    void Awake()
    {
        // Get components
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerCamera = GetComponentInChildren<Camera>();

        // Get input actions
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        jumpAction = playerInput.actions["Jump"];
        sprintAction = playerInput.actions["Sprint"];
        interactAction = playerInput.actions["Interact"];
        attackAction = playerInput.actions["Attack"];

        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnEnable()
    {
        // Subscribe to button events
        jumpAction.performed += OnJumpPressed;
        interactAction.performed += OnInteractPressed;
        attackAction.performed += OnAttackPressed;
        sprintAction.performed += OnSprintStarted;
        sprintAction.canceled += OnSprintEnded;
    }

    void OnDisable()
    {
        // Unsubscribe from events
        jumpAction.performed -= OnJumpPressed;
        interactAction.performed -= OnInteractPressed;
        attackAction.performed -= OnAttackPressed;
        sprintAction.performed -= OnSprintStarted;
        sprintAction.canceled -= OnSprintEnded;
    }

    void Update()
    {
        HandleGroundCheck();
        HandleMovement();
        HandleMouseLook();
        HandleGravity();
    }

    private void HandleGroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void HandleMovement()
    {
        // Read movement input
        movementInput = moveAction.ReadValue<Vector2>();

        // Calculate movement direction
        Vector3 moveDirection = transform.right * movementInput.x + transform.forward * movementInput.y;

        // Apply speed (walk or sprint)
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        // Move the character
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        // Read look input
        lookInput = lookAction.ReadValue<Vector2>();

        // Calculate rotation
        float mouseX = lookInput.x * lookSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * lookSensitivity * Time.deltaTime;

        // Vertical look (up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotations
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleGravity()
    {
        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    #region Input Event Handlers

    private void OnJumpPressed(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            OnJump?.Invoke();
        }
    }

    private void OnInteractPressed(InputAction.CallbackContext context)
    {
        OnInteract?.Invoke();
        Debug.Log("Interact pressed!");

        // You can add raycast interaction logic here
        TryInteractWithObject();
    }

    private void OnAttackPressed(InputAction.CallbackContext context)
    {
        OnAttack?.Invoke();
        Debug.Log("Attack!");

        // Add your attack logic here
        PerformAttack();
    }

    private void OnSprintStarted(InputAction.CallbackContext context)
    {
        isSprinting = true;
    }

    private void OnSprintEnded(InputAction.CallbackContext context)
    {
        isSprinting = false;
    }

    #endregion

    #region Action Methods

    private void TryInteractWithObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 3f))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    private void PerformAttack()
    {
        // Add your attack logic here
        // Example: raycast for damage, play animation, etc.
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 5f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy: " + hit.collider.name);
            }
        }
    }

    #endregion

    // Public methods to control input programmatically
    public void EnableInput()
    {
        playerInput.ActivateInput();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DisableInput()
    {
        playerInput.DeactivateInput();
        Cursor.lockState = CursorLockMode.None;
    }

    // Getters for other scripts
    public bool IsMoving => movementInput.magnitude > 0.1f;
    public bool IsSprinting => isSprinting;
    public Vector3 MovementDirection => new Vector3(movementInput.x, 0, movementInput.y);
}

// Interface for interactable objects
public interface IInteractable
{
    void Interact();
}