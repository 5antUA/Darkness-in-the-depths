using UnityEngine;

public class DamagerTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.GetComponent<Player>().Health -= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventManager.ShowDamageScreen();
        }
    }
}
