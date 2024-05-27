using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunScript : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;
    private List<GameObject> currentBullets = new List<GameObject>();

    public float shootForce;
    public float spread;

    public int quantityOfBullets;
    private bool coolDown = true;
    private Coroutine cooldownCoroutine;
    private int counterOfBullets = 3;
    private bool reload = true;
    private Coroutine reloadCoroutine;

    private Animator ShotGunAnimator;
    private AudioSource audio;
    public AudioClip fireSoundShotGun;
    public ParticleSystem muzzleFlash;

    private void Start()
    {
        audio = GetComponent<AudioSource>();    
        ShotGunAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            ShotGunAnimator.SetBool("SGisWalking", true);
        else
            ShotGunAnimator.SetBool("SGisWalking", false);

        if (Input.GetMouseButtonDown(0))
        {
            if (coolDown)
            {
                Shoot();
                ShotGunAnimator.SetTrigger("ShotGunFire");
                audio.PlayOneShot(fireSoundShotGun);
                muzzleFlash.Play();

                counterOfBullets--;
                cooldownCoroutine = StartCoroutine(Coolldown());
            }
        }
        
        if (counterOfBullets == 0 && reload)
        {
            reloadCoroutine = StartCoroutine(Reload());
            ShotGunAnimator.SetTrigger("ShotGunReload");
            Debug.Log("reload");
            counterOfBullets = 3;
            coolDown = false;
        }
    }

    private void OnDisable()
    {
        if (cooldownCoroutine != null)
        {
            StopCoroutine(cooldownCoroutine);
            coolDown = true;
        }

        if (reloadCoroutine != null)
        {
            StopCoroutine(reloadCoroutine);
            reload = true;
        }
    }

    private void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        for (int i = 0; i < quantityOfBullets; i++)
        {
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

            InstBullet(dirWithSpread);
        }
    }

    private void InstBullet(Vector3 dirWithSpread)
    {
        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);
        currentBullets.Add(currentBullet);
        currentBullet.transform.forward = dirWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }

    private IEnumerator Coolldown()
    {
        coolDown = false;
        yield return new WaitForSeconds(1.7f);
        coolDown = true;
    }

    private IEnumerator Reload()
    {
        reload = false;
        yield return new WaitForSeconds(5f);
        reload = true;
        coolDown = true;
    }
}
