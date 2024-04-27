using UnityEngine;
using RostykEnums;
using System.IO; // custom namespace


// ������ ������ �� ������� ������ ������
public class Player : Character
{
    [Header("\t PLAYER SPECIAL")]
    [Space]

    
    #region Player properties
    // STORAGE SERVICES
    private string InputDataKey;                                // ���� ���������� InputData
    private SavingToFile storage;                               // ������ � ������� ���������� � ��������

    // VALUES
    public Gamemode GameMode;                                   // ������� �����
    public float CrouchHeight;                                  // ������ ����������
    public float JumpForce;                                     // ���� ������

    private bool isSprint;                                      // ���� �����
    private bool isCrouch;                                      // ���� �������� �����
    private float _gravity = -9.81f;                            // ��������� ���������� ������� g
    private Vector3 _velocity;                                  // ����������� ������

    // COMPONENTS
    [SerializeField] private Camera PlayerCamera;               // Camera ������
    [SerializeField] private Light PlayerLight;                 // Player flashlight
    private CharacterController _controller;

    // KEYS CONTROL
    private KeyCode SprintButton;
    private KeyCode CrouchButton;
    private KeyCode JumpButton;
    private KeyCode SwitchLightButton;
    #endregion


    #region Management
    private void Awake()
    {
        InputDataKey = SavedData.InputData.KEY;
        storage = new SavingToFile();
        InitPlayerControl();
    }

    private void Start()
    {
        _controller = this.GetComponent<CharacterController>();
        isCrouch = false;
        PlayerLight.enabled = false;
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
    // ������������ ������
    private void Movement()
    {
        _controller.Move(_velocity * Time.deltaTime * WalkSpeed);
    }

    // ������ ����������� �������� ���������
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

    // ������ ����������
    private void Crouch()
    {
        if (Input.GetKey(CrouchButton))
        {
            _controller.height = Mathf.Lerp(_controller.height, CrouchHeight, 6f * Time.deltaTime);
            isCrouch = true;
        }
        else
        {
            _controller.height = 1.8f;
            isCrouch = false;
        }
    }

    // ������ ������� ���������
    private void Jump()
    {
        if (_controller.isGrounded)
        {
            _velocity.y = Input.GetKeyDown(JumpButton) ? JumpForce : -0.1f;
        }
        else if (!_controller.isGrounded)
        {
            _velocity.y += _gravity * Time.deltaTime;
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
        try
        {
            storage.Load<SavedData.InputData>(InputDataKey, data =>
            {
                SprintButton = data.RunButton;
                CrouchButton = data.CrouchButton;
                JumpButton = data.JumpButton;
                SwitchLightButton = data.FlashlightButton;
            });
        }
        catch (FileNotFoundException)
        {
            storage.Save(InputDataKey, new SavedData.InputData());
            InitPlayerControl();
        }
    }
    #endregion
}
