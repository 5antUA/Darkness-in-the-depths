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

        HitDistance = 2f;
        MyPlayer = this.GetComponent<Player>();

        PlayerDamage = MyPlayer.Damage;
        WeaponMode = WeaponMode.Pistol;
    }

    private void Update()
    {
        if (Input.GetKeyDown(InputData.Interact))
        {
            Interact();
        }
    }

    #region Shooting

    //// Логика взаемодействия во врага
    private void Interact()
    {
        SimpleDoor door = GetObject();
        if (door != null)
        {
            if(door.isOpen)
                door.CloseDoor();
            else if(!door.isOpen)
                door.OpenDoor();
        }
        // если не попал во врага
        else
        {
        }
    }

    // Поиск врага лучем
    private SimpleDoor GetObject()
    {
        RaycastHit hit = GetComponentInChildren<ThrowRay>().GetHit(HitDistance);

        if (hit.collider != null)
        {
            return hit.collider.GetComponentInChildren<SimpleDoor>();
        }
        else
        {
            return null;
        }
    }
    #endregion
}