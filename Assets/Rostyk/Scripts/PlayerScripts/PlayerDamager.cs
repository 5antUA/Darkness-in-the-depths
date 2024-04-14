using System.Collections;
using System.Threading;
using UnityEngine;
using RostykEnums;
using System.Runtime.InteropServices.WindowsRuntime; // custom namespace


// СКРИПТ ВЕШАТЬ НА ИГРОКА
public class PlayerDamager : MonoBehaviour
{
    public WeaponMode WeaponMode = WeaponMode.Knife;            // какой тип оружия держит персонаж сейчас
    private float PlayerDamage;                                 // урон, расчитаный по формуле (ориг.Damage в Character)
    private float HitDistance;                                  // дальность удара или стрельбы

    [Space]
    [SerializeField] private Transform _startShooter;           // точка начала выброса луча
    private Player MyPlayer;                                    // скрипт this.Player
    public float BulletSpeed;                                   // скорость пули


    private void Start()
    {
        MyPlayer = this.GetComponent<Player>();
        PlayerDamage = MyPlayer.Damage;
        HitDistance = GetRayDistance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetHitInfo();
            Shooting();
        }

        WeaponController();
    }


    #region Shooting
    // Логика стрельбы во врага
    private void Shooting()
    {
        Monster enemy = GetEnemy();

        // если попал во врага
        if (enemy != null)
        {
            enemy.TakeDamage(PlayerDamage);
            Debug.Log(PlayerDamage);

            if (enemy.isDead)
            {
                Destroy(enemy.gameObject);
            }
        }
        // если не попал во врага
        else
        {
            Debug.Log("EBLAN, YOU MISSED!");
        }
    }

    // Поиск врага лучем
    private Monster GetEnemy()
    {
        RaycastHit hit = GetComponentInChildren<ThrowRay>().GetHit(HitDistance);

        if (hit.collider != null)
        {
            return hit.collider.GetComponentInParent<Monster>();
        }
        else
        {
            return null;
        }
    }

    // Бросок луча и вывод инфо о hit
    private void GetHitInfo()
    {
        RaycastHit hit = GetComponentInChildren<ThrowRay>().GetHit(HitDistance);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
    }
    #endregion


    #region Weapon controller
    // Weapon controller
    private void WeaponController()
    {
        ReorderWeaponModeButton();
        ReorderWeaponModeScroll();

        HitDistance = GetRayDistance();
    }

    // Сменить режим оружия по нажатию кнопки
    private void ReorderWeaponModeButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            WeaponMode = WeaponMode.Knife;

        else if (Input.GetKeyDown(KeyCode.Alpha2))
            WeaponMode = WeaponMode.Weapon;

        else if (Input.GetKeyDown(KeyCode.Alpha3))
            WeaponMode = WeaponMode.Grenade;
    }

    // Сменить режим оружия по скролу колесика мыши
    private void ReorderWeaponModeScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            WeaponMode++;

            if ((int)WeaponMode == 4)
                WeaponMode = WeaponMode.Knife;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            WeaponMode--;

            if ((int)WeaponMode == 0)
                WeaponMode = WeaponMode.Grenade;
        }
    }

    // Получение дальности атаки в зависимости от режима оружия
    private float GetRayDistance()
    {
        if (WeaponMode == WeaponMode.Knife)
            return 3f;

        else if (WeaponMode == WeaponMode.Weapon)
            return 100f;

        else if (WeaponMode == WeaponMode.Grenade)
            return 0;

        else
            return 0;
    }
    #endregion
}