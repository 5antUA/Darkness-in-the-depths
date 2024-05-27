using System.Collections;
using UnityEngine;

public class PistolScript : Weapon
{
    private SavedData.InputData InputData;

    [Space]
    [Header("\t OTHER PROPERTIES")]
    public GameObject bullet;
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

    [SerializeField] private GameObject MenuUI;


    #region Unity methods
    private void Start()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();

        fireAudioSource = GetComponent<AudioSource>();
        PistolAnimator = GetComponent<Animator>();

        counterOfBullets = MaxBullets;
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
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }
}
