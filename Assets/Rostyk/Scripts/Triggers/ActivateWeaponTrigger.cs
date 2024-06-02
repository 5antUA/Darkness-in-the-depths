using System.Collections;
using UnityEngine;

public class ActivateWeaponTrigger : MonoBehaviour
{
    SavedData.WeaponData data;

    [Range(0, 2)]
    public int WeaponNumber;


    private void Start()
    {
        data = new SavedData.WeaponData();
        data = data.Load();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            data.Weapons[WeaponNumber] = true;
            data.Save();

            Destroy(this.gameObject);
        }
    }
}