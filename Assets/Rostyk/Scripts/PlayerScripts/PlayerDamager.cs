using UnityEngine;
using RostykEnums; // custom namespace


// СКРИПТ ВЕШАТЬ НА ИГРОКА
public class PlayerDamager : MonoBehaviour
{
    private SavedData.InputData InputData;

    public WeaponMode WeaponMode;                               // какой тип оружия держит персонаж сейчас
    private float PlayerDamage;                                 // урон, расчитаный по формуле (ориг.Damage в Character)
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
        WeaponMode = WeaponMode.Weapon;
        HitDistance = GetRayDistance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(InputData.Shoot))
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
        ChangeWeaponModeButton();
        ChangeWeaponModeScroll();

        HitDistance = GetRayDistance();
    }

    // Сменить режим оружия по нажатию кнопки
    private void ChangeWeaponModeButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            WeaponMode = WeaponMode.Knife;

        else if (Input.GetKeyDown(KeyCode.Alpha2))
            WeaponMode = WeaponMode.Weapon;

        else if (Input.GetKeyDown(KeyCode.Alpha3))
            WeaponMode = WeaponMode.Grenade;
    }

    // Сменить режим оружия по скролу колесика мыши
    private void ChangeWeaponModeScroll()
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

        else
            return 0;
    }
    #endregion
}