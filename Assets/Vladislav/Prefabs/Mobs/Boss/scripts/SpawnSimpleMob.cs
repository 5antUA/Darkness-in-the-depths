using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SpawnSimpleMob : MonoBehaviour
{
    public int MaxMobsValue = 6;
    public float CorutineTime = 3f;
    public BossTrigerControl bossPlase;
    private bool isstopcorutine = false;
    
    public GameObject mobs;
    public Transform[] spawnpoints;

    private GameObject boss;
    private ParticleSystem[] firePoints;

    private void Start()
    {
        firePoints = new ParticleSystem[spawnpoints.Length];
        this.gameObject.SetActive(false);
        for(int i=0; i < spawnpoints.Length; i++)
            firePoints[i] = spawnpoints[i].GetChild(0).gameObject.GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && MaxMobsValue >= MaxMobsValue-3)
        {
            boss = bossPlase.getBoss();
            print("player in trigger");
            isstopcorutine = true;
            boss.GetComponent<Animator>().SetBool("Following", false);
            StartCoroutine(routine: AnimationSpawnStart());
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isstopcorutine = false;
            boss.GetComponent<Animator>().SetBool("Following", true);
            print("stop");
        }
    }
    private IEnumerator AnimationSpawnStart()
    {
        while (isstopcorutine)
        {
            yield return new WaitForSeconds(CorutineTime);
            if (isstopcorutine)
            {
                print("we thare");
                boss.GetComponent<Animator>().SetTrigger("SpawnAtack");
                print("SpawnAtack");
                yield return new WaitForSeconds(1f);
                FireAktive();
                yield return new WaitForSeconds(1.5f);
                for (int i = 0; i < spawnpoints.Length; i++)
                {
                    Instantiate(mobs, spawnpoints[i].position, Quaternion.identity);
                }
            }
        }
    }
    private void FireAktive()
    {
        for (int i = 0; i < spawnpoints.Length; i++)
            firePoints[i].Play();
    }

}
