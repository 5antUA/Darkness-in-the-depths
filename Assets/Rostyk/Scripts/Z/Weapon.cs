using UnityEngine;
using SavedData;


public class Weapon : MonoBehaviour
{
    [Space]
    [Header("\t ABSTRACT PROPERTIES")]
    [HideInInspector] public bool isReload;
    [HideInInspector] public int counterOfBullets;
    public int MaxBullets;
    public float _distance;

    protected int MagazineCapacity;
    protected int TotalAmmo;
    protected int ShootCooldown;
    protected int ReloadTime;
}
