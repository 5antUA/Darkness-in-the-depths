using UnityEngine;

public class BossTrigerControl : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject Spawnsimplemob;
    public Transform spawnpoint;
    private GameObject boss;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            boss = Instantiate(bossPrefab, spawnpoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            boss.GetComponent<Animator>().SetTrigger("introStart");
            Spawnsimplemob.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    public GameObject getBoss()
    {
        return boss;
    }

}
