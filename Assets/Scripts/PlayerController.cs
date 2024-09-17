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
    [SerializeField] private bool canJump = true;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        canJump = Physics.Raycast(groundCheck.position, Vector3.down, groundLayer);
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
        if (context.performed)
        {
            _compRigidbody.velocity = new Vector3(_compRigidbody.velocity.x, 0f, _compRigidbody.velocity.z);
            _compRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = true; 
        }
    }
}