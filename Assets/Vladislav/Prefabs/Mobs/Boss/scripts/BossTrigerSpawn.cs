using Unity.VisualScripting;
using UnityEngine;

namespace mobs
{
    public class BossTrigerControl : MonoBehaviour
    {
        public GameObject bossPrefab;
        public GameObject Spawnsimplemob;
        public Transform spawnpoint;
        private GameObject boss;
        private Sounds sound;

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Player"))
            {
                boss = Instantiate(bossPrefab, spawnpoint.position, Quaternion.identity);
                sound=boss.GetComponent<Sounds>();
                sound.PlaySound(sound.sounds[1], volume: 3, p1: 1.8f, p2: 2f);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Spawnsimplemob.SetActive(true);
                boss.GetComponent<Animator>().SetTrigger("introStart");///
                sound.PlaySound(sound.sounds[0], volume:8,p1: 1.2f, p2: 1.3f);
                Destroy(this.gameObject);
            }
        }

        public GameObject getBoss()
        {
            return boss;
        }
    }
}
