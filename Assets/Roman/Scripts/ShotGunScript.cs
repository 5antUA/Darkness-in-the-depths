using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunScript : Weapon
{
    private SavedData.InputData InputData;
    private SavedData.CharacterData characterData;
    [Space]
    [Header("\t OTHER PROPERTIES")]
    private float characterDamage;
    public int BulletsPerShoot;
    public Camera mainCamera;
    public Transform spawnBullet;
    public Player Player;

    public AudioClip fireAudioClip;
    public AudioClip reloadAudioClip;
    public ParticleSystem muzzleFlash;

    private bool isCooldown;
    private bool reload;
    private Animator ShotGunAnimator;
    private AudioSource AudioSource;
    private Coroutine cooldownCoroutine;
    private Coroutine reloadCoroutine;
    [SerializeField] private GameObject MenuUI;

    private bool shootingWhileRun = false;// Роз'яснення для Ростіка: змінна фіксить баг, а саме: коли рухаєшся анімація стрільби не відіграється.
                      // Якщо її не добавляти, анімація стрільби буде програватися після анімації бігу(з умовою, якщо будеш стріляти під час бігу). 


    #region Unity methods
    private void Start()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();

        characterData = new SavedData.CharacterData();
        characterData = characterData.Load();
        characterDamage = characterData.Property.Damage;

        AudioSource = GetComponent<AudioSource>();
        ShotGunAnimator = GetComponent<Animator>();

        counterOfBullets = MaxBullets;
        _distance = 10f;
        isCooldown = true;
        reload = false;
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
        if (cooldownCoroutine != null)
        {
            StopCoroutine(cooldownCoroutine);
            isCooldown = true;
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
            if (isCooldown && !reload)
            {
                ShootLogic();

                if(!shootingWhileRun)
                    ShotGunAnimator.SetTrigger("ShotGunFire");
                
                AudioSource.PlayOneShot(fireAudioClip);
                muzzleFlash.Play();

                counterOfBullets--;
                cooldownCoroutine = StartCoroutine(CooldownCoroutine());
            }
        }
    }

    private void Reload()
    {
        if (counterOfBullets == 0 && !reload)
        {
            reloadCoroutine = StartCoroutine(ReloadCoroutine());
            ShotGunAnimator.SetTrigger("ShotGunReload");
            Invoke("SoundOfReload", 0.6f);
            Debug.Log("reload");
            isCooldown = false;
        }
        else if(Input.GetKeyDown(InputData.Reload) && counterOfBullets < MaxBullets && !reload)
        {
            reloadCoroutine = StartCoroutine(ReloadCoroutine());
            ShotGunAnimator.SetTrigger("ShotGunReload");
            SoundOfReload();
            Debug.Log("reload");
            isCooldown = false;
        }
    }

    private void PlayWalkAnimation()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {

            ShotGunAnimator.SetBool("SGisWalking", true);
            shootingWhileRun = true;
        }
        else
        {
            ShotGunAnimator.SetBool("SGisWalking", false);
            shootingWhileRun = false;
        }

    }

    private void SoundOfReload()
    {
        AudioSource.PlayOneShot(reloadAudioClip);
    }

    #endregion


    #region Coroutines
    private IEnumerator CooldownCoroutine()
    {
        isCooldown = false;
        yield return new WaitForSeconds(1.7f);
        isCooldown = true;
    }

    private IEnumerator ReloadCoroutine()
    {
        reload = true;
        yield return new WaitForSeconds(5f);
        counterOfBullets = MaxBullets; // counterOfBullets = 3
        reload = false;
        isCooldown = true;
    }
    #endregion


    private void ShootLogic()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, _distance))
        {
            Monster enemy = hit.collider.GetComponentInParent<Monster>();
            if (enemy != null)
            {
                float distance = Vector3.Distance(mainCamera.transform.position, hit.transform.position);
                enemy.TakeDamage((60 - (distance * 6)) * characterDamage);
            }
        }
    }
}
