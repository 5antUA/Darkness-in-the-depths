using System.Collections;
using System.Threading;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;
    private int counterOfBullets = 0;
    public GameObject Pistol;

    public float shootForce;
    public float spread;

    private bool coolDown = true;
    private Coroutine coolDownCoroutine;

    private bool reload = true;
    private Coroutine reloadCoroutine;
    public AudioClip reloadSound;

    public ParticleSystem muzzleFlash;
    
    private AudioSource audio;
    public AudioClip fireSound;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            Pistol.GetComponent<Animator>().SetBool("isWalk", true);
        else
            Pistol.GetComponent<Animator>().SetBool("isWalk", false);

        if (Input.GetMouseButtonDown(0))
        {
            if (coolDown)
            {
                Shoot();

                Pistol.GetComponent<Animator>().SetTrigger("Fire");
                audio.PlayOneShot(fireSound);

                muzzleFlash.Play();

                counterOfBullets++;

                if (counterOfBullets == 7 && reload)
                {
                    reloadCoroutine = StartCoroutine(Reload());
                    Pistol.GetComponent<Animator>().SetTrigger("Reload");

                    Invoke("SoundOfReload", 0.6f);

                    Debug.Log("reload");
                    counterOfBullets = 0;
                    coolDown = false;
                }
                else
                {
                    coolDownCoroutine = StartCoroutine(Coolldown());
                }
            }
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

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }

    private IEnumerator Coolldown()
    {
        coolDown = false;
        yield return new WaitForSeconds(1f);
        coolDown = true;
    }

    private IEnumerator Reload()
    {
        reload = false;
        yield return new WaitForSeconds(3f);
        reload = true;
        coolDown = true;
    }

    private void SoundOfReload()
    {
        audio.PlayOneShot(reloadSound);
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
            reload = true;
        }
    }
}
