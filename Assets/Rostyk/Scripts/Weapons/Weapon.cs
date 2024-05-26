using UnityEngine;


public class Weapon : MonoBehaviour
{
    [Space]
    [Header("\t ABSTRACT PROPERTIES")]
    [HideInInspector] public bool isReload;
    [HideInInspector] public int counterOfBullets;
    public int MaxBullets;
    public float shootForce;
    public float spread;

    protected int MagazineCapacity;
    protected int TotalAmmo;
    protected int ShootCooldown;
    protected int ReloadTime;
}