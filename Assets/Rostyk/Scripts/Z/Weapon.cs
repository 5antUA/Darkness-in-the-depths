using UnityEngine;
using SavedData;


public class Weapon : MonoBehaviour
{
    public bool isReload { get; protected set; }
    [HideInInspector] public int counterOfBullets;
    public int MaxBullets;
    public float _distance;

    protected int MagazineCapacity;
    protected int TotalAmmo;
    protected int ShootCooldown;
    protected int ReloadTime;
}
