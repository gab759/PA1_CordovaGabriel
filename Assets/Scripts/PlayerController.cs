using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _compRigidbody;
    private Vector2 movement;
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int maxJumps = 2;
    private int jumpCount;
    private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private float groundCheckRadius = 0.2f;

    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>() * velocity;
    }

    private void Move()
    {
        _compRigidbody.velocity = new Vector3(movement.x, _compRigidbody.velocity.y, movement.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && (isGrounded || jumpCount < maxJumps))
        {
            _compRigidbody.velocity = new Vector3(_compRigidbody.velocity.x, 0f, _compRigidbody.velocity.z);
            _compRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }
}