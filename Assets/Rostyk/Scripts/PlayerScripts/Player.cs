using UnityEngine;


// ³���� ����� �� ������� ��'��� ������
public class Player : Character
{
    #region Player properties
    [SerializeField] private Light PlayerLight;                 // Light (�������)
    [SerializeField] private GameObject MenuUI;                 // GameObject ���� ������

    public float CrouchHeight;                                  // ������ ���������
    public float JumpForce;                                     // ���� ������
    public Camera PlayerCamera;                                 // Camera (������� ������ ������)
    public AudioClip SprintSound;                               // AudioClip ���
    public AudioClip WalkingSound;                              // AudioClip ������
    public AudioClip CrouchSound;                               // AudioClip ������� ������

    public CharacterController Controller => _controller;       // ���������� CharacterController

    private bool _isSprint;                                     // ���� �����...
    private bool _isCrouch;                                     // ���� ������� ������...
    private float _defaultFOV;                                  // ���� ���� ������ �� ������������
    private float _defaultControllerHeight;                     // ������ ������ �� ������������
    private float _gravity = -9.81f;                            // ����������� ������� ������ g
    private Vector3 _velocity;                                  // ������ ����������� ������
    private CharacterController _controller;                    // ��������� CharacterController
    private AudioSource _audioSource;                           // _audioSource ��� ����������� �����
    private SavedData.InputData _inputData;                     // ��� ��� ������
    #endregion


    #region MONOBEHAVIOUR
    // ����� Awake, ���� ����������� ����� ������� Start (����� ������� ���)
    private void Awake()
    {
        _inputData = new SavedData.InputData();
        _inputData = _inputData.Load();
    }

    // ����� Start, ���� ����������� �� ������� ���
    private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
        _controller = this.GetComponent<CharacterController>();
        _isCrouch = false;
        _defaultFOV = PlayerCamera.fieldOfView;
        _defaultControllerHeight = _controller.height;
        PlayerLight.enabled = false;
    }

    // ����� Update, ���� ���������� ����� ���� ���� ��'��� ��������
    private void Update()
    {
        if (!MenuUI.activeInHierarchy)
        {
            Movement();
            SoundOfWalk();
            Crouch();
            ChangeFieldOfView();
            Jump();
            SwitchFlashlightMode();
        }

        if (this.IsDead)
        {
            MenuUI.SetActive(false);
            EventManager.OnPlayerDeath();
        }
    }

    // ����� FixedUpdate, ���� ���������� ���� 0.02 ��� �� ���� ��'��� ��������
    private void FixedUpdate()
    {
        if (this.IsDead)
            return;

        CalculateVelocity();
    }
    #endregion


    #region Player behaviour
    // ���������� ������ �� ������������
    private void Movement()
    {
        _controller.Move(_velocity * Time.deltaTime * WalkSpeed);
    }

    // ���������� ������� ����������� ������ �� ���� ��������
    private void CalculateVelocity()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 _direction = new Vector3(moveX, 0, moveZ);

        if (Input.GetKey(_inputData.Run) && Input.GetAxis("Vertical") > 0 && !_isCrouch)
        {
            _direction *= SprintSpeed;
            _isSprint = true;
        }
        else if (Input.GetKey(_inputData.Crouch))
        {
            _direction *= CrouchSpeed;
            _isSprint = false;
        }
        else
        {
            _direction *= WalkSpeed;
            _isSprint = false;
        }

        Vector3 move = Quaternion.Euler(0, PlayerCamera.transform.eulerAngles.y, 0) *
            new Vector3(_direction.x, 0, _direction.z);
        _velocity = new Vector3(move.x, _velocity.y, move.z);
    }

    // ����������� ����� ������
    private void SoundOfWalk()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && Controller.isGrounded)
        {
            if (_isSprint && !_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(SprintSound);
            }
            else if (_isCrouch && !_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(CrouchSound);
            }
            else if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(WalkingSound);
            }
        }
    }

    // ����� ��������� ������
    private void Crouch()
    {
        if (Input.GetKey(_inputData.Crouch))
        {
            _controller.height = Mathf.Lerp(_controller.height, CrouchHeight, 6f * Time.deltaTime);
            _isCrouch = true;
        }
        else
        {
            _controller.height = _defaultControllerHeight;
            _isCrouch = false;
        }
    }

    // ����� ������� ���������
    private void Jump()
    {
        if (_controller.isGrounded)
        {
            _velocity.y = Input.GetKey(_inputData.Jump) ? JumpForce : -0.1f;
        }
        else if (!_controller.isGrounded)
        {
            _velocity.y += _gravity * Time.deltaTime;
        }
    }

    // ���� ���� ���� ������
    private void ChangeFieldOfView()
    {
        if (_isSprint)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, _defaultFOV + 25, 5f * Time.deltaTime);
        }
        else if (_isCrouch)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, _defaultFOV - 15, 5f * Time.deltaTime);
        }
        else
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, _defaultFOV, 5f * Time.deltaTime);
        }
    }

    // ������������ ������ ��������
    private void SwitchFlashlightMode()
    {
        if (Input.GetKeyDown(_inputData.SwitchLight))
        {
            PlayerLight.enabled = PlayerLight.enabled ? false : true;
        }
    }
    #endregion
}