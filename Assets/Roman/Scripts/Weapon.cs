using UnityEngine;
using SavedData;


public class Weapon : MonoBehaviour
{
    public bool isReload { get; protected set; }
    public int counterOfBullets { get; set; }
    public int MaxBullets;
    public float _distance;

    protected int MagazineCapacity;
    protected int TotalAmmo;
    protected int ShootCooldown;
    protected int ReloadTime;
}
