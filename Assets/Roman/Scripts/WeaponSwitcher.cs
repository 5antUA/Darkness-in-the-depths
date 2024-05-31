using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private SavedData.WeaponData EnabledWeaponData;
    [SerializeField] private int weaponSwitch = 0;
    [SerializeField] private PistolScript pistolScript;


    void Start()
    {
        EnabledWeaponData = new SavedData.WeaponData();
        EnabledWeaponData = EnabledWeaponData.Load();

        SelectWeapon();
    }

    void Update()
    {
        KeysWeaponSwitch();
        
        int currentWeapon = weaponSwitch;
        if (currentWeapon == weaponSwitch)
        {
            SelectWeapon();
        }
    }


    private void KeysWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EnabledWeaponData = EnabledWeaponData.Load();
            if (EnabledWeaponData.Weapons[0])
                weaponSwitch = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !pistolScript.isReload)
        {
            EnabledWeaponData = EnabledWeaponData.Load();
            if (EnabledWeaponData.Weapons[1])
                weaponSwitch = 1;
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in this.transform)
        {
            if (i == weaponSwitch)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
