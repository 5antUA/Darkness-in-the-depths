using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunScript : Weapon
{
    private SavedData.InputData InputData;
    [Space]
    [Header("\t OTHER PROPERTIES")]
    public int BulletsPerShoot;
    public GameObject BulletPrefab;
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
    private List<GameObject> currentBullets;
    [SerializeField] private GameObject MenuUI;

    private bool shootingWhileRun = false;// Роз'яснення для Ростіка: змінна фіксить баг, а саме: коли рухаєшся анімація стрільби не відіграється.
                      // Якщо її не добавляти, анімація стрільби буде програватися після анімації бігу(з умовою, якщо будеш стріляти під час бігу). 


    #region Unity methods
    private void Start()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();

        AudioSource = GetComponent<AudioSource>();
        ShotGunAnimator = GetComponent<Animator>();

        counterOfBullets = MaxBullets;
        isCooldown = true;
        reload = false;
        currentBullets = new List<GameObject>();
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

    private void InstBullet(Vector3 dirWithSpread)
    {
        GameObject currentBullet = Instantiate(BulletPrefab, spawnBullet.position, Quaternion.identity);
        currentBullets.Add(currentBullet);
        currentBullet.transform.forward = dirWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
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
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        for (int i = 0; i < BulletsPerShoot; i++)
        {
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

            InstBullet(dirWithSpread);
        }
    }
}
