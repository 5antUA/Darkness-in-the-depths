using UnityEngine;


public abstract class Weapon : MonoBehaviour
{
    protected float Damage;
    protected float BulletSpeed;
    protected int Ammo;
    protected int MagazineCapacity;
    protected int TotalAmmo;
    protected float Spread;
    protected float ShootCooldown;
    protected float ReloadTime;


    protected abstract void Shoot();
    protected virtual void Reload() { }
}