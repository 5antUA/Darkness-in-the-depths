using UnityEngine;

public class Gun : Weapon
{
    SavedData.InputData InputData;

    public Gun()
    {
        Damage = 30;
        BulletSpeed = 30;
        Ammo = 30;
        MagazineCapacity = 30;
        TotalAmmo = 120;
        Spread = 1;
        ShootCooldown = 1f;
        ReloadTime = 3.5f;
    }


    private void Start()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();
    }

    private void Update()
    {
        Reload();
    }

    protected override void Reload()
    {
        if (Ammo == 30 || TotalAmmo == 0)
        {
            return;
        }

        if (Input.GetKeyDown(InputData.Reload))
        {
            // количество нужных патронов для перезарядки
            int patrons = MagazineCapacity - Ammo;

            if (patrons > TotalAmmo)
            {
                Ammo += TotalAmmo;
                TotalAmmo = 0;
            }
            else if (patrons <= TotalAmmo)
            {
                Ammo = 30;
                TotalAmmo -= patrons;
            }
        }
    }


    protected override void Shoot()
    {
        return;
    }
}