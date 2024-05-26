using UnityEngine;

public class Gun : Weapon
{
    SavedData.InputData InputData;

    public Gun()
    {
        counterOfBullets = 30;
        MagazineCapacity = 30;
        TotalAmmo = 120;
        ShootCooldown = 1;
        ReloadTime = 3;
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

    protected void Reload()
    {
        if (counterOfBullets == 30 || TotalAmmo == 0)
        {
            return;
        }

        if (Input.GetKeyDown(InputData.Reload))
        {
            // количество нужных патронов для перезарядки
            int patrons = MagazineCapacity - counterOfBullets;

            if (patrons > TotalAmmo)
            {
                counterOfBullets += TotalAmmo;
                TotalAmmo = 0;
            }
            else if (patrons <= TotalAmmo)
            {
                counterOfBullets = 30;
                TotalAmmo -= patrons;
            }
        }
    }
}