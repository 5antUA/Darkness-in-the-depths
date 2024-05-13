using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace mobs {

    
    public class SpawnSimpleMob : MonoBehaviour
    {

        public static int MonsterCounter = 0;

        public float CorutineTime = 3f;
        public BossTrigerControl bossPlase;
        public GameObject mobs;
        public Transform[] spawnpoints;

        private bool IsContinueCoroutine = false;
        private const int MaxMobsValue = 6;

        private GameObject boss;
        private ParticleSystem[] firePoints;

        private void Start()
        {
            firePoints = new ParticleSystem[spawnpoints.Length];
            this.gameObject.SetActive(false);
            for (int i = 0; i < spawnpoints.Length; i++)
                firePoints[i] = spawnpoints[i].GetChild(0).gameObject.GetComponent<ParticleSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Player"))
            {
                boss = bossPlase.getBoss();
                print("player in trigger");
                IsContinueCoroutine = true;
                boss.GetComponent<Animator>().SetBool("Following", false);
                StartCoroutine(routine: AnimationSpawnStart());
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                IsContinueCoroutine = false;
                boss.GetComponent<Animator>().SetBool("Following", true);
                print("stop");
            }
        }
        private IEnumerator AnimationSpawnStart()
        {
            while (IsContinueCoroutine)
            {
                yield return new WaitForSeconds(CorutineTime);
                if (IsContinueCoroutine && MonsterCounter <= 3)
                {
                    print("we thare");
                    boss.GetComponent<Animator>().SetTrigger("SpawnAtack");
                    print("SpawnAtack");
                    yield return new WaitForSeconds(1f);
                    FireAktive();
                    yield return new WaitForSeconds(1.5f);
                    MonsterCounter += 3;
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
}
