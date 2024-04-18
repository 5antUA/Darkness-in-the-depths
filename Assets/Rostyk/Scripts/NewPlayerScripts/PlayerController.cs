using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private Camera PlayerCamera;
    private CharacterController _CharacterController;

    public float JumpForce;
    private float Gravity = -9.81f;
    private Vector3 _direction;
    private Vector3 _velocity;

    private void Start()
    {
        _CharacterController = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
        _CharacterController.Move(_velocity * Time.deltaTime * WalkSpeed);
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        _direction = new Vector3(moveX, 0, moveZ);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _direction *= SprintSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _direction *= CrouchSpeed;
        }
        else
        {
            _direction *= WalkSpeed;
        }
        Vector3 move = Quaternion.Euler(0, PlayerCamera.transform.eulerAngles.y, 0) * 
            new Vector3(_direction.x, 0, _direction.z);
        _velocity = new Vector3(move.x, _velocity.y, move.z);
    }

    private void Jump()
    {
        if (_CharacterController.isGrounded)
        {
            _velocity.y = Input.GetKeyDown(KeyCode.Space) ? JumpForce : -0.1f;
        }
        else
        {
            _velocity.y += Gravity * Time.deltaTime;
        }
    }
}
