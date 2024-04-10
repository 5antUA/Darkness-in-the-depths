using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [Header("\t PLAYER SPECIAL")]
    [Space]


    #region Monster properties
    // INSPECTOR
    public Gamemode GameMode = Gamemode.survival;    // игровой режим
    public float JumpForce;                                // сила прыжка
    public float MaxVelocity;                              // ? ? ?
    [SerializeField] private Camera PlayerCamera;          // игровая камера

    // NOT INSPECTOR                                        
    private bool isSprinting;                              // если бежит
    private bool inGround;                                 // если на земле

    // COMPONENTS
    private Rigidbody _rb;
    #endregion



    #region Management
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _rb = GetComponent<Rigidbody>();

        inGround = true;
    }

    private void Update()
    {
        Jump();
        ChangeFieldOfView();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    #endregion

    #region Movement/Rotation
    // Логика движения персонажа
    private void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        // Проверка на ходьбу
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // Проверка на бег
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0)
            {
                direction = transform.TransformDirection(direction) * SprintSpeed;
                isSprinting = true;
            }
            else
            {
                direction = transform.TransformDirection(direction) * WalkSpeed;
                isSprinting = false;
            }

            // Логика движения
            Vector3 velocity = _rb.velocity;
            Vector3 velocityChange = (direction - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -MaxVelocity, MaxVelocity);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -MaxVelocity, MaxVelocity);
            velocityChange.y = 0;

            _rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
        else
        {
            isSprinting = false;
            return;
        }
    }

    // Логика прыжков персонажа
    private void Jump()
    {
        if (Input.GetButton("Jump") && inGround)
        {
            _rb.AddForce(Vector3.up * JumpForce);
        }
    }

    // смена поля зрения при беге
    private void ChangeFieldOfView()
    {
        if (isSprinting)
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, 80f, 5f * Time.deltaTime);
        else
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, 60f, 5f * Time.deltaTime);
    }
    #endregion
}
