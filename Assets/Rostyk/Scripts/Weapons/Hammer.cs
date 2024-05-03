using UnityEngine;

public class Hammer : Weapon
{
    public Hammer()
    {
        Damage = 10;
        ShootCooldown = 1;

        BulletSpeed = 0;
        Ammo = 0;
        MagazineCapacity = 0;
        TotalAmmo = 0;
        Spread = 0;
        ReloadTime = 0;
    }


    protected override void Shoot()
    {
        
    }
}