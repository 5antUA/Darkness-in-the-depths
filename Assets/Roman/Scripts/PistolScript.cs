using System.Collections;
using UnityEngine;

public class PistolScript : Weapon
{
    private SavedData.InputData InputData;
    private SavedData.CharacterData characterData;

    [Space]
    [Header("\t OTHER PROPERTIES")]
    private float characterDamage;
    public Camera mainCamera;
    public Transform spawnBullet;
    public GameObject Pistol;
    public Player Player;

    private bool coolDown;
    private Coroutine coolDownCoroutine;
    private Coroutine reloadCoroutine;

    public AudioClip reloadAudioClip;
    public AudioClip fireAudioClip;
    private AudioSource fireAudioSource;

    public ParticleSystem muzzleFlash;
    private Animator PistolAnimator;

    public GameObject PistolHitEffect;

    [SerializeField] private GameObject MenuUI;


    #region Unity methods
    private void Start()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();

        characterData = new SavedData.CharacterData();
        characterData = characterData.Load();
        characterDamage = characterData.Property.Damage;

        fireAudioSource = GetComponent<AudioSource>();
        PistolAnimator = GetComponent<Animator>();

        counterOfBullets = MaxBullets;
        _distance = 100f;
        coolDown = true;
        isReload = false;
    }

    void Update()
    {
        if (Player.IsDead || MenuUI.activeInHierarchy)
            return;

        Shoot();
        Reload();
        PlayWalkAnimation();
    }

    private void OnDisable()
    {
        if (coolDownCoroutine != null)
        {
            StopCoroutine(coolDownCoroutine);
            coolDown = true;
        }

        if (reloadCoroutine != null)
        {
            StopCoroutine(reloadCoroutine);
        }
    }
    #endregion


    #region Shoot management
    private void Shoot()
    {
        if (Input.GetKeyDown(InputData.Shoot))
        {
            if (coolDown && !isReload)
            {
                ShootLogic();

                PistolAnimator.SetTrigger("Fire");
                fireAudioSource.PlayOneShot(fireAudioClip);
                muzzleFlash.Play();

                counterOfBullets--;
                coolDownCoroutine = StartCoroutine(CooldownCoroutine());
            }
        }
    }

    private void Reload()
    {
        if (counterOfBullets == 0 && !isReload)
        {
            reloadCoroutine = StartCoroutine(ReloadCoroutine());

            PistolAnimator.SetTrigger("Reload");
            Invoke("SoundOfReload", 0.6f);

            Debug.Log("reload");
            coolDown = false;
        }
        else if (Input.GetKeyDown(InputData.Reload) && counterOfBullets < MaxBullets && !isReload)
        {
            reloadCoroutine = StartCoroutine(ReloadCoroutine());

            PistolAnimator.SetTrigger("Reload");
            SoundOfReload();

            Debug.Log("reload");
            coolDown = false;
        }
    }

    private void PlayWalkAnimation()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            PistolAnimator.SetBool("isWalk", true);
        else
            PistolAnimator.SetBool("isWalk", false);
    }

    private void SoundOfReload()
    {
        fireAudioSource.PlayOneShot(reloadAudioClip);
    }
    #endregion


    #region Coroutines
    private IEnumerator CooldownCoroutine()
    {
        coolDown = false;
        yield return new WaitForSeconds(1f);
        coolDown = true;
    }

    private IEnumerator ReloadCoroutine()
    {
        isReload = true;
        yield return new WaitForSeconds(3f);
        counterOfBullets = MaxBullets; // counterOfBullets = 7;
        isReload = false;
        coolDown = true;
    }
    #endregion


    private void ShootLogic()
    {
        RaycastHit hit;

        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, _distance))
        {
            Monster enemy = hit.collider.GetComponentInParent<Monster>();
            if (enemy != null)
            {
                enemy.TakeDamage(20 * characterDamage);
                GameObject effect = Instantiate(PistolHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(effect, 1f);
            }
        }
    }
}
