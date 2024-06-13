using System.Collections;
using UnityEngine;

public class ActivateWeaponTrigger : MonoBehaviour
{
    SavedData.WeaponData data;

    [Range(1, 2)]
    public int WeaponNumber;


    private void Start()
    {
        data = new SavedData.WeaponData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            data = data.Load();
            data.Weapons[WeaponNumber] = true;
            data.Save();

            Destroy(this.gameObject);
        }
    }
}