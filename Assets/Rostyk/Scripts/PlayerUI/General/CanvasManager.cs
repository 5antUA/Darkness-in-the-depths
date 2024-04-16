using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ СКРИП НА ОБЪЕКТ PlayerUI
public class CanvasManager : MonoBehaviour
{
    public Text PlayerInfo;                                    // информация об игроке (Text UI)
    public GameObject MenuUI;                                  // MenuUI
    private Player MyPlayer;                                   // скрипт this.Player
    private PlayerDamager PlayerDmgr;                          // скрипт this.PlayerDamager


    private void Start()
    {
        MyPlayer = GetComponentInParent<Player>();
        PlayerDmgr = GetComponentInParent<PlayerDamager>();
    }

    private void Update()
    {
        if (PlayerInfo.enabled == true)
            UpdatePlayerInfo();

        EnablePlayerInfo();
    }


    // Скрыть или показать данные об игроке
    private void EnablePlayerInfo()
    {
        if (Input.GetKeyDown(KeyCode.Q) && PlayerInfo.enabled == true)
        {
            PlayerInfo.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && PlayerInfo.enabled == false)
        {
            if (MenuUI.activeInHierarchy)
            {
                return;
            }
            else
            {
                PlayerInfo.enabled = true;
            }
        }
    }

    // Обновление данных игрока
    private void UpdatePlayerInfo()
    {
        PlayerInfo.text =
            $"Health : {MyPlayer.Health}\n" +
            $"Gamemode : {MyPlayer.GameMode}\n" +
            $"WeaponMode : {PlayerDmgr.WeaponMode} \n" +
            $"Weapon : - \n\n" +
            $"Press TAB to open menu";
    }
}
