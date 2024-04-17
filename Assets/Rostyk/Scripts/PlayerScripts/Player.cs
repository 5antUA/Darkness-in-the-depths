using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RostykEnums; // custom namespace


// ������ ������ �� ������� ������ ������
public class Player : Character
{
    [Header("\t PLAYER SPECIAL")]
    [Space]


    #region Player properties
    // VALUES
    public Gamemode GameMode;                              // ������� �����
    public float CrouchHeight;                             // ������ ����������
    public float JumpForce;                                // ���� ������
    public float MaxVelocity;                              // ? ? ?
    private bool isSprint;                                 // ���� �����
    private bool isCrouch;                                 // ���� �������� �����
    private bool inGround;                                 // ���� �� �����

    // COMPONENTS
    [SerializeField] private Camera PlayerCamera;          // Camera ������
    [SerializeField] private Light PlayerLight;            // Player flashlight
    private Rigidbody _rigidBody;                          // Rigidbody ������
    private CapsuleCollider _capsuleCollider;              // Capsule collider ������

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
    // ������ ����������� �������� ���������
    private void Movement()
    {
        _rigidBody.isKinematic = false;
        _rigidBody.useGravity = true;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        // �������� �� ������
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // �������� �� ���
            if (Input.GetKey(SprintButton) && Input.GetAxis("Vertical") > 0 && !isCrouch)
            {
                direction = transform.TransformDirection(direction) * SprintSpeed;
                isSprint = true;
            }
            // �������� �� ��������� ������
            else if (isCrouch)
            {
                direction = transform.TransformDirection(direction) * CrouchSpeed;
                isSprint = false;
            }
            // ��� ������� ������
            else
            {
                direction = transform.TransformDirection(direction) * WalkSpeed;
                isSprint = false;
            }

            // ������ ��������
            Vector3 velocity = _rigidBody.velocity;
            Vector3 velocityChange = direction - velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -MaxVelocity, MaxVelocity);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -MaxVelocity, MaxVelocity);
            velocityChange.y = 0;

            _rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
        }
        // ���� �������� �����
        else
        {
            isSprint = false;
        }
    }

    // ������ ������������� �������� ��������� (CreativeMode)
    private void CreativeMovement()
    {
        _rigidBody.isKinematic = true;
        _rigidBody.useGravity = false;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // �������� �� �����
        if (Input.GetKey(JumpButton))
        {
            Vector3 direction = new Vector3(moveX, 1, moveZ);
            transform.Translate(direction * Time.deltaTime * FlySpeed);
        }
        // �������� �� �������
        else if (Input.GetKey(CrouchButton))
        {
            Vector3 direction = new Vector3(moveX, -1, moveZ);
            transform.Translate(direction * Time.deltaTime * FlySpeed);
        }
        // ��� �������������� ������������
        else
        {
            Vector3 direction = new Vector3(moveX, 0, moveZ);
            transform.Translate(direction * Time.deltaTime * FlySpeed, Space.Self);
        }
    }

    // ������ ����������
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

    // ������ ������� ���������
    private void Jump()
    {
        if (Input.GetKey(JumpButton) && inGround)
        {
            _rigidBody.AddForce(Vector3.up * JumpForce);
        }
    }

    // ����� ���� ������
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

    // ��������� ��� ���������� ��������
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

    // ����������
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
