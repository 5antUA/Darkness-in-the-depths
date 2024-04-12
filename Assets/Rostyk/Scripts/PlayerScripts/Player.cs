using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RostykEnums; // custom namespace


// ВЕШАТЬ СКРИПТ НА БАЗОВЫЙ ОБЪЕКТ ИГРОКА
public class Player : Character
{
    [Header("\t PLAYER SPECIAL")]
    [Space]


    #region Monster properties
    // VALUES
    public Gamemode GameMode = Gamemode.survival;          // игровой режим
    public float JumpForce;                                // сила прыжка
    public float MaxVelocity;                              // ? ? ?

    private bool isSprint;                                 // если бежит
    private bool isCrouch;                                 // если медленно ходит
    private bool inGround;                                 // если на земле

    // COMPONENTS
    [SerializeField] private Camera PlayerCamera;          // Camera камера
    private Rigidbody _rb;                                 // Rigidbody игрока

    // BUTTONS
    private KeyCode SprintButton;
    private KeyCode CrouchButton;
    private KeyCode JumpButton;
    #endregion


    #region Management
    private void Start()
    {
        InitPlayerControl();

        _rb = GetComponent<Rigidbody>();
        inGround = true;
    }

    private void Update()
    {
        Jump();
        ChangeFOV();
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
            if (Input.GetKey(SprintButton) && Input.GetAxis("Vertical") > 0)
            {
                direction = transform.TransformDirection(direction) * SprintSpeed;
                isSprint = true;
                isCrouch = false;
            }
            // Проверка на медленную ходьбу
            else if (Input.GetKey(CrouchButton))
            {
                direction = transform.TransformDirection(direction) * CrouchSpeed;
                isCrouch = true;
                isSprint = false;
            }
            // При обычной ходьбе
            else
            {
                direction = transform.TransformDirection(direction) * WalkSpeed;
                isSprint = false;
                isCrouch = false;
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
            isSprint = false;
            isCrouch = false;
            return;
        }
    }

    // Логика прыжков персонажа
    private void Jump()
    {
        if (Input.GetKey(JumpButton) && inGround)
        {
            _rb.AddForce(Vector3.up * JumpForce);
        }
    }

    // Смена поля зрения
    private void ChangeFOV()
    {
        if (isSprint)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, 80f, 5f * Time.deltaTime);
        }
        else if (isCrouch)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, 45f, 5f * Time.deltaTime);
        }
        else
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, 60f, 5f * Time.deltaTime);
        }
    }

    // Управление
    private void InitPlayerControl()
    {
        SprintButton = KeyCode.LeftControl;
        CrouchButton = KeyCode.LeftShift;
        JumpButton = KeyCode.Space;
    }
    #endregion


    #region Collision / Trigger
    private void OnCollisionExit(Collision collision)
    {
        GroundChecker(collision, false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GroundChecker(collision, true);
    }

    private void GroundChecker(Collision collision, bool inGround)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.inGround = inGround;
        }
    }
    #endregion
}
