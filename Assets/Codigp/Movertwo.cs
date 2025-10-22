using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movertwo : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private Vector2 moveInput;
    private bool isGrounded;

    // Para el nuevo Input System
    private PlayerInput playerInput;

    private void Awake()
    {


        playerInput = GetComponent<PlayerInput>();
        isGrounded = true;
    }

    // Para el nuevo Input System
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Movimiento más consistente usando Rigidbody
        Vector2 targetVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
        rb.linearVelocity = targetVelocity;

        // Alternativa para movimiento más suave:
        // rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, acceleration * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        isGrounded = false;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);

        // Alternativa con AddForce:
        // rb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("piso"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("piso"))
        {
            isGrounded = false;
        }
    }


}
