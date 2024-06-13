using System.Collections;
using UnityEngine;

public class ArraySpawn : MonoBehaviour
{
    public GameObject prefabs;
    public float SpawnDelay = 2;
    private Transform[] spawnTransform;
    private bool isSpawning = false;

    private void Start()
    {
        spawnTransform = new Transform[this.transform.childCount];
         for (int i = 0; i < this.transform.childCount; i++)
            spawnTransform[i] = this.transform.GetChild(i).GetComponent<Transform>(); 
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
        foreach (Transform t in spawnTransform)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(prefabs, t.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}