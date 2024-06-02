using System.Collections;
using UnityEngine;

public class TiranSpawnTriggerControl : MonoBehaviour
{
    public GameObject prefabs;
    public int SpawnDelay=2;
    private Transform spawnTransform;
    private ParticleSystem particleSystem;
    private AudioSource audioSource;
    private bool isSpawning = false;

    private void Start()
    {
        spawnTransform = this.gameObject.transform.GetChild(0);
        particleSystem = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(spawnManager());
        }
    }

    private IEnumerator spawnManager()
    {
        yield return new WaitForSeconds(SpawnDelay);
        audioSource.Play();
        particleSystem.Play();
        yield return new WaitForSeconds(1f);
        Instantiate(prefabs, spawnTransform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
