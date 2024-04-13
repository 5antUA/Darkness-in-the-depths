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
    public Gamemode GameMode = Gamemode.survival;          // ������� �����
    public float JumpForce;                                // ���� ������
    public float MaxVelocity;                              // ? ? ?
    private bool isSprint;                                 // ���� �����
    private bool isCrouch;                                 // ���� �������� �����
    private bool inGround;                                 // ���� �� �����

    // COMPONENTS
    [SerializeField] private Camera PlayerCamera;          // Camera ������
    private Rigidbody _rigidBody;                          // Rigidbody ������
    private BoxCollider _boxCollider;                      // Box Collider ������

    // KEYS CONTROL
    private KeyCode SprintButton;
    private KeyCode CrouchButton;
    private KeyCode JumpButton;
    #endregion


    #region Management
    private void Start()
    {
        InitPlayerControl();
        inGround = true;

        _rigidBody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        Jump();
        ChangeFOV();
    }

    private void FixedUpdate()
    {
        if (GameMode != Gamemode.creative)
        {
            _rigidBody.isKinematic = false;
            _rigidBody.useGravity = true;
            Movement();
        }
        else
        {
            _rigidBody.isKinematic = true;
            _rigidBody.useGravity = false;
            CreativeMovement();
        }
    }
    #endregion


    #region Player behaviour
    // ������ ����������� �������� ���������
    private void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        // �������� �� ������
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // �������� �� ���
            if (Input.GetKey(SprintButton) && Input.GetAxis("Vertical") > 0)
            {
                direction = transform.TransformDirection(direction) * SprintSpeed;
                isSprint = true;
                isCrouch = false;
            }
            // �������� �� ��������� ������
            else if (Input.GetKey(CrouchButton))
            {
                direction = transform.TransformDirection(direction) * CrouchSpeed;
                isCrouch = true;
                isSprint = false;
            }
            // ��� ������� ������
            else
            {
                direction = transform.TransformDirection(direction) * WalkSpeed;
                isSprint = false;
                isCrouch = false;
            }

            // ������ ��������
            Vector3 velocity = _rigidBody.velocity;
            Vector3 velocityChange = (direction - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -MaxVelocity, MaxVelocity);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -MaxVelocity, MaxVelocity);
            velocityChange.y = 0;

            _rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
        }
        // ���� �������� �����
        else
        {
            isSprint = false;
            isCrouch = false;
            return;
        }
    }

    // ������ ������������� �������� ��������� (CreativeMode)
    private void CreativeMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // �������� �� �����
        if (Input.GetKey(JumpButton))
        {
            Vector3 direction = new Vector3(moveX, 1, moveZ);
            transform.Translate(direction * Time.deltaTime * CreativeSpeed);
        }
        // �������� �� �������
        else if (Input.GetKey(CrouchButton))
        {
            Vector3 direction = new Vector3(moveX, -1, moveZ);
            transform.Translate(direction * Time.deltaTime * CreativeSpeed);
        }
        // ��� �������������� ������������
        else
        {
            Vector3 direction = new Vector3(moveX, 0, moveZ);
            transform.Translate(direction * Time.deltaTime * CreativeSpeed, Space.Self);
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
        else if (isCrouch)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, 45f, 5f * Time.deltaTime);
        }
        else
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, 60f, 5f * Time.deltaTime);
        }
    }

    // ����������
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
