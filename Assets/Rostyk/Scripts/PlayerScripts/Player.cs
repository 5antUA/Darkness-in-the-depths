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
    public float MaxVelocity;                              // ? ? ?
    private bool isSprint;                                 // если бежит
    private bool isCrouch;                                 // если медленно ходит
    private bool inGround;                                 // если на земле

    // COMPONENTS
    [SerializeField] private Camera PlayerCamera;          // Camera игрока
    [SerializeField] private Light PlayerLight;            // Player flashlight
    private Rigidbody _rigidBody;                          // Rigidbody игрока
    private CapsuleCollider _capsuleCollider;              // Capsule collider игрока

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
        inGround = false;
        isCrouch = false;
        PlayerLight.enabled = false;
        GameMode = Gamemode.survival;

        _rigidBody = this.GetComponent<Rigidbody>();
        _capsuleCollider = this.GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        ChangeFOV();
        SwitchLight();
    }

    private void FixedUpdate()
    {
        if (GameMode != Gamemode.creative)
        {
            Movement();
            Crouch();
            Jump();
        }
        else
        {
            CreativeMovement();
        }
    }
    #endregion


    #region Player behaviour
    // Логика физического движения персонажа
    private void Movement()
    {
        _rigidBody.isKinematic = false;
        _rigidBody.useGravity = true;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        // Проверка на ходьбу
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // Проверка на бег
            if (Input.GetKey(SprintButton) && Input.GetAxis("Vertical") > 0 && !isCrouch)
            {
                direction = transform.TransformDirection(direction) * SprintSpeed;
                isSprint = true;
            }
            // Проверка на медленную ходьбу
            else if (isCrouch)
            {
                direction = transform.TransformDirection(direction) * CrouchSpeed;
                isSprint = false;
            }
            // При обычной ходьбе
            else
            {
                direction = transform.TransformDirection(direction) * WalkSpeed;
                isSprint = false;
            }

            // Логика движения
            Vector3 velocity = _rigidBody.velocity;
            Vector3 velocityChange = direction - velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -MaxVelocity, MaxVelocity);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -MaxVelocity, MaxVelocity);
            velocityChange.y = 0;

            _rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
        }
        // Если персонаж стоит
        else
        {
            isSprint = false;
        }
    }

    // Логика НЕфизического движения персонажа (CreativeMode)
    private void CreativeMovement()
    {
        _rigidBody.isKinematic = true;
        _rigidBody.useGravity = false;

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
            _capsuleCollider.height = Mathf.Lerp(_capsuleCollider.height, CrouchHeight, 6f * Time.deltaTime);
            isCrouch = true;
        }
        else
        {
            _capsuleCollider.height = Mathf.Lerp(_capsuleCollider.height, 1.8f, 6f * Time.deltaTime);
            isCrouch = false;
        }
    }

    // Логика прыжков персонажа
    private void Jump()
    {
        if (Input.GetKey(JumpButton) && inGround)
        {
            _rigidBody.AddForce(Vector3.up * JumpForce);
        }
    }

    // Смена поля зрения
    private void ChangeFOV()
    {
        if (isSprint)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, 80f, 5f * Time.deltaTime);
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
