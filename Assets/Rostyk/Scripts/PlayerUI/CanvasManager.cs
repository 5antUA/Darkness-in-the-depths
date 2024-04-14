using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ СКРИП НА ОБЪЕКТ PlayerUI
public class CanvasManager : MonoBehaviour
{
    public Text PlayerInfo;                     // информация об игроке (Text UI)
    private Player MyPlayer;                    // скрипт this.Player
    private PlayerDamager PlayerDmgr;           // скрипт this.PlayerDamager


    private void Start()
    {
        MyPlayer = GetComponentInParent<Player>();
        PlayerDmgr = GetComponentInParent<PlayerDamager>();
    }

    private void Update()
    {
        if (PlayerInfo != null)
            UpdatePlayerInfo();

        GetComponent<InventoryManager>().InventoryControl();
    }

    // Обновление данных игрока
    private void UpdatePlayerInfo()
    {
        PlayerInfo.text =
            $"Health : {MyPlayer.Health}\n" +
            $"Gamemode : {MyPlayer.GameMode}\n" +
            $"WeaponMode : {PlayerDmgr.WeaponMode} \n" +
            $"Weapon : - ";
    }
}
