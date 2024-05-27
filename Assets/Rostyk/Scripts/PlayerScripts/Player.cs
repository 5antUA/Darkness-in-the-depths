using UnityEngine;
using RostykEnums;
using UnityEngine.SceneManagement;


// ������ ������ �� ������� ������ ������
public class Player : Character
{
    [Header("\t PLAYER SPECIAL")]
    [Space]


    #region Player properties
    // STORAGE SERVICES
    private SavedData.InputData InputData;

    // VALUES
    public float CrouchHeight;                                  // ������ ����������
    public float JumpForce;                                     // ���� ������
    public int LockOpeningTime;                                 // ����� ������ ������
    public bool isNotPenetation = false;

    private bool isSprint;                                      // ���� �����
    private bool isCrouch;                                      // ���� �������� �����
    private float defoltFOV;
    private float _gravity = -9.81f;                            // ��������� ���������� ������� g
    private Vector3 _velocity;                                  // ����������� ������

    // COMPONENTS
    [SerializeField] private Camera PlayerCamera;               // Camera ������
    [SerializeField] private Light PlayerLight;                 // Player flashlight
    [SerializeField] private GameObject MenuUI;
    private CharacterController _controller;
    #endregion


    #region Management
    private void Awake()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();
    }

    private void Start()
    {
        _controller = this.GetComponent<CharacterController>();
        isCrouch = false;
        PlayerLight.enabled = false;
        defoltFOV = PlayerCamera.fieldOfView;
    }

    private void Update()
    {
        if (!MenuUI.activeInHierarchy)
        {
            Movement();
            Jump();
            Crouch();
            ChangeFOV();
            SwitchLight();
        }

        if (this.IsDead && !isNotPenetation)
        {
            MenuUI.SetActive(false);
            EventManager.OnPlayerDeath();
        }
    }

    private void FixedUpdate()
    {
        if (this.IsDead)
            return;

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

        if (Input.GetKey(InputData.Run) && Input.GetAxis("Vertical") > 0 && !isCrouch)
        {
            _direction *= SprintSpeed;
            isSprint = true;
        }
        else if (Input.GetKey(InputData.Crouch))
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
        if (Input.GetKey(InputData.Crouch))
        {
            _controller.height = Mathf.Lerp(_controller.height, CrouchHeight, 6f * Time.deltaTime);
            isCrouch = true;
        }
        else
        {
            _controller.height = 1.6f;
            isCrouch = false;
        }
    }

    // ������ ������� ���������
    private void Jump()
    {
        if (_controller.isGrounded)
        {
            _velocity.y = Input.GetKeyDown(InputData.Jump) ? JumpForce : -0.1f;
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
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, defoltFOV + 25, 5f * Time.deltaTime);
        }
        else if (isCrouch)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, defoltFOV - 15, 5f * Time.deltaTime);
        }
        else
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, defoltFOV, 5f * Time.deltaTime);
        }
    }
    // ��������� ��� ���������� ��������
    private void SwitchLight()
    {
        if (Input.GetKeyDown(InputData.SwitchLight) && PlayerLight.enabled == false)
        {
            PlayerLight.enabled = true;
        }
        else if (Input.GetKeyDown(InputData.SwitchLight) && PlayerLight.enabled == true)
        {
            PlayerLight.enabled = false;
        }
    }
    #endregion
}