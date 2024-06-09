using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawn : MonoBehaviour
{
    public GameObject prefabs;
    public float SpawnDelay = 2;
    private Transform spawnTransform;
    private bool isSpawning = false;

    private void Start()
    {
        spawnTransform = this.transform.GetChild(0).GetComponent<Transform>();    
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
        Instantiate(prefabs, spawnTransform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
