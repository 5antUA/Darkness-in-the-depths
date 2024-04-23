using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RostykEnums; // custom namespace


// ВЕШАТЬ СКРИПТ НА БАЗОВЫЙ ОБЪЕКТ ИГРОКА
public class Player : Character
{
    [Header("\t PLAYER SPECIAL")]
    [Space]


    #region Player properties
    // VALUES
    public Gamemode GameMode;                              // игровой режим
    public float CrouchHeight;                             // Высота прыседания
    public float JumpForce;                                // сила прыжка

    private bool isSprint;                                 // если бежит
    private bool isCrouch;                                 // если медленно ходит
    private float _gravity = -9.81f;                       // ускорение свободного падения g
    private Vector3 _velocity;                             // направление игрока

    // COMPONENTS
    [SerializeField] private Camera PlayerCamera;          // Camera игрока
    [SerializeField] private Light PlayerLight;            // Player flashlight
    private CharacterController _Controller;

    // KEYS CONTROL
    private KeyCode SprintButton;
    private KeyCode CrouchButton;
    private KeyCode JumpButton;
    private KeyCode SwitchLightButton;
    #endregion


    #region Management
    private void Start()
    {
        InitPlayerControl();
        isCrouch = false;
        PlayerLight.enabled = false;
        GameMode = Gamemode.survival;

        _Controller = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        Jump();
        Crouch();
        ChangeFOV();
        SwitchLight();
    }

    private void FixedUpdate()
    {
        CalculateVelocity();
    }
    #endregion


    #region Player behaviour
    // Логика физического движения персонажа
    private void Movement()
    {
        _Controller.Move(_velocity * Time.deltaTime * WalkSpeed);
    }

    //
    private void CalculateVelocity()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 _direction = new Vector3(moveX, 0, moveZ);

        if (Input.GetKey(SprintButton) && Input.GetAxis("Vertical") > 0 && !isCrouch)
        {
            _direction *= SprintSpeed;
            isSprint = true;
        }
        else if (Input.GetKey(CrouchButton))
        {
            _direction *= CrouchSpeed;
            isSprint = false;
        }
        else
        {
            _direction *= WalkSpeed;
            isSprint = false;
        }
        Vector3 move = Quaternion.Euler(0, PlayerCamera.transform.eulerAngles.y, 0) *
            new Vector3(_direction.x, 0, _direction.z);
        _velocity = new Vector3(move.x, _velocity.y, move.z);
    }

    // Логика НЕфизического движения персонажа (CreativeMode)
    private void CreativeMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Проверка на полет
        if (Input.GetKey(JumpButton))
        {
            Vector3 direction = new Vector3(moveX, 1, moveZ);
            transform.Translate(direction * Time.deltaTime * FlySpeed);
        }
        // Проверка на посадку
        else if (Input.GetKey(CrouchButton))
        {
            Vector3 direction = new Vector3(moveX, -1, moveZ);
            transform.Translate(direction * Time.deltaTime * FlySpeed);
        }
        // При горизонтальном передвижении
        else
        {
            Vector3 direction = new Vector3(moveX, 0, moveZ);
            transform.Translate(direction * Time.deltaTime * FlySpeed, Space.Self);
        }
    }

    // Логика приседания
    private void Crouch()
    {
        if (Input.GetKey(CrouchButton))
        {
            _Controller.height = Mathf.Lerp(_Controller.height, CrouchHeight, 6f * Time.deltaTime);
            isCrouch = true;
        }
        else
        {
            _Controller.height = 1.8f;
            isCrouch = false;
        }
    }

    // Логика прыжков персонажа
    private void Jump()
    {
        if (_Controller.isGrounded)
        {
            _velocity.y = Input.GetKeyDown(KeyCode.Space) ? JumpForce : -0.1f;
        }
        else if (!_Controller.isGrounded)
        {
            _velocity.y += _gravity * Time.deltaTime;
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

    // Включение или выключение фонарика
    private void SwitchLight()
    {
        if (Input.GetKeyDown(SwitchLightButton) && PlayerLight.enabled == false)
        {
            PlayerLight.enabled = true;
        }
        else if (Input.GetKeyDown(SwitchLightButton) && PlayerLight.enabled == true)
        {
            PlayerLight.enabled = false;
        }
    }

    // Управление
    private void InitPlayerControl()
    {
        SprintButton = KeyCode.LeftControl;
        CrouchButton = KeyCode.LeftShift;
        JumpButton = KeyCode.Space;
        SwitchLightButton = KeyCode.F;
    }
    #endregion
}
