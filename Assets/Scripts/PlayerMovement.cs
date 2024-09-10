using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform orientation;
    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _moveDirection;
    
    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    [SerializeField] private bool canJump;
    
    [Header("Ground Checking")] 
    [SerializeField] private float playerHeight;
    [SerializeField] private float groundDrag;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;

    
  
    private Rigidbody _rb;
  

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerInput();

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

        if (isGrounded)
        {
            _rb.drag = groundDrag;
        }
        else
        {
            _rb.drag = groundDrag;

        }

      
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void PlayerInput()
    {
        // _horizontalInput = joystick.Horizontal;
        // _verticalInput = joystick.Vertical;
        
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        // if (Input.GetKey(KeyCode.Space) && isGrounded && canJump)
        // {
        //     canJump = false;
        //     
        //     Jump();
        //     
        //     Invoke(nameof(ResetJump), jumpCooldown);
        // }
    }

    void MovePlayer()
    {
        _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

        if (isGrounded)
        {
            _rb.AddForce(_moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!isGrounded)
        {
            _rb.AddForce(_moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

    }

    void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        
        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        canJump = true;
    }
}
