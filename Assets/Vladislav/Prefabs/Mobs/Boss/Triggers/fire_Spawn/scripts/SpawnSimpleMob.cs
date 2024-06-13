using System.Collections;
using UnityEngine;

namespace mobs
{
    public class SpawnSimpleMob : MonoBehaviour
    {

        public static int MonsterCounter = 0;

        public float CorutineTime = 3f;
        public BossTrigerControl bossPlase;
        public GameObject mobs;
        public Transform[] spawnpoints;

        private bool IsContinueCoroutine = true;

        private GameObject boss;
        private Animator animator;
        private ParticleSystem[] firePoints;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource= GetComponent<AudioSource>();
            firePoints = new ParticleSystem[spawnpoints.Length];
            for (int i = 0; i < spawnpoints.Length; i++)
                firePoints[i] = spawnpoints[i].GetChild(0).gameObject.GetComponent<ParticleSystem>();
            this.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (IsContinueCoroutine == false && MonsterCounter <= 3)
                animator.SetBool("Following", true);
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Player"))
            {
                boss = bossPlase.getBoss();
                animator = boss.GetComponent<Animator>();
                IsContinueCoroutine = true;
                print("enemy in trigger");
                animator.SetBool("Following", false);
                StartCoroutine(routine: AnimationSpawnStart());
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                IsContinueCoroutine = false;
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
                    MonsterCounter += 3;
                    boss.GetComponent<Animator>().SetTrigger("SpawnAtack");
                    yield return new WaitForSeconds(1f);
                    FireAktive();
                    audioSource.PlayOneShot(audioSource.clip, volumeScale:4);
                    yield return new WaitForSeconds(1.5f);
                    print("SpawnAtack");
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
