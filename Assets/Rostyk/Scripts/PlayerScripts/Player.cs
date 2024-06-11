using UnityEngine;


// ¬≥шати скр≥пт на базовий об'Їкт гравц€
public class Player : Character
{
    #region Player properties
    [SerializeField] private Light PlayerLight;                 // Light (фонарик)
    [SerializeField] private GameObject MenuUI;                 // GameObject меню гравц€

    public float CrouchHeight;                                  // ¬исота прис≥данн€
    public float JumpForce;                                     // сила прижка
    public Camera PlayerCamera;                                 // Camera (головна камера гравц€)
    public AudioClip SprintSound;                               // AudioClip б≥гу
    public AudioClip WalkingSound;                              // AudioClip ходьби
    public AudioClip CrouchSound;                               // AudioClip пов≥льноњ ходьби

    public CharacterController Controller => _controller;       // властив≥сть CharacterController

    private bool _isSprint;                                     // €кщо б≥жить...
    private bool _isCrouch;                                     // €кщо пов≥льно ходить...
    private float _defaultFOV;                                  // поле зору гравц€ по замовчуванню
    private float _defaultControllerHeight;                     // висота гравц€ по замовчуванню
    private float _gravity = -9.81f;                            // прискоренн€ в≥льного пад≥нн€ g
    private Vector3 _velocity;                                  // вектор направленн€ гравц€
    private CharacterController _controller;                    // приватний CharacterController
    private AudioSource _audioSource;                           // _audioSource дл€ програванн€ звук≥в
    private SavedData.InputData _inputData;                     // дан≥ про клав≥ш≥
    #endregion


    #region MONOBEHAVIOUR
    // метод Awake, €кий запускаЇтьс€ перед методом Start (перед стартом гри)
    private void Awake()
    {
        _inputData = new SavedData.InputData();
        _inputData = _inputData.Load();
    }

    // метод Start, €кий запускаЇтьс€ на початку гри
    private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
        _controller = this.GetComponent<CharacterController>();
        _isCrouch = false;
        _defaultFOV = PlayerCamera.fieldOfView;
        _defaultControllerHeight = _controller.height;
        PlayerLight.enabled = false;
    }

    // метод Update, €кий виконуЇтьс€ кожен кадр поки об'Їкт активний
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

    // метод FixedUpdate, €кий виконуЇтьс€ кожн≥ 0.02 сек та поки об'Їкт активний
    private void FixedUpdate()
    {
        if (this.IsDead)
            return;

        CalculateVelocity();
    }
    #endregion


    #region Player behaviour
    // ѕерем≥щенн€ гравц€ за направленн€м
    private void Movement()
    {
        _controller.Move(_velocity * Time.deltaTime * WalkSpeed);
    }

    // ќбчисленн€ вектору направленн€ гравц€ та його швидкост≥
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

    // ѕрограванн€ звук≥в ходьби
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

    // Ћог≥ка прис≥данн€ гравц€
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

    // Ћог≥ка стрибк≥в персонажа
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

    // «м≥на пол€ зору гравц€
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

    // ѕереключенн€ режиму фонарика
    private void SwitchFlashlightMode()
    {
        if (Input.GetKeyDown(_inputData.SwitchLight))
        {
            PlayerLight.enabled = PlayerLight.enabled ? false : true;
        }
    }
    #endregion
}