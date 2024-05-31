using UnityEngine;
using RostykEnums; // custom namespace


// СКРИПТ ВЕШАТЬ НА ИГРОКА
public class PlayerDamager : MonoBehaviour
{

    private SavedData.InputData InputData;

    public WeaponMode WeaponMode;                               // какой тип оружия держит персонаж сейчас
    private float PlayerDamage;                                 // урон, расчитаный по формуле (ориг.Damage в Properties)
    private float HitDistance;                                  // дальность удара или стрельбы

    [Space]
    [SerializeField] private Transform _startShooter;           // точка начала выброса луча
    private Player MyPlayer;                                    // скрипт this.Player

    private void Start()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();

        MyPlayer = this.GetComponent<Player>();

        PlayerDamage = MyPlayer.Damage;
        WeaponMode = WeaponMode.Pistol;
        HitDistance = GetRayDistance();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(InputData.Shoot))
    //    {
    //        Shooting();
    //    }

    //    WeaponController();
    //}

    #region Shooting

    //// Логика стрельбы во врага
    private void Shooting()
    {
        Monster enemy = GetEnemy();

        // если попал во врага
        if (enemy != null)
        {
            enemy.TakeDamage(PlayerDamage);
            Debug.Log(PlayerDamage);


        }
        // если не попал во врага
        else
        {
            // Debug.Log("EBLAN, YOU MISSED!");
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
    #endregion


    #region Weapon controller
    // Weapon controller
    private void WeaponController()
    {
        ChangeWeaponModeButton();

        HitDistance = GetRayDistance();
    }

    // Сменить режим оружия по нажатию кнопки
    private void ChangeWeaponModeButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            WeaponMode = WeaponMode.Hummer;

        else if (Input.GetKeyDown(KeyCode.Alpha2))
            WeaponMode = WeaponMode.Pistol;

        else if (Input.GetKeyDown(KeyCode.Alpha3))
            WeaponMode = WeaponMode.Shotgun;
    }

    // Получение дальности атаки в зависимости от режима оружия
    private float GetRayDistance()
    {
        if (WeaponMode == WeaponMode.Hummer)
            return 3f;

        else if (WeaponMode == WeaponMode.Pistol)
            return 100f;
        
        else if (WeaponMode == WeaponMode.Shotgun)
            return 16f;
        
        return 0;
    }
    #endregion
}