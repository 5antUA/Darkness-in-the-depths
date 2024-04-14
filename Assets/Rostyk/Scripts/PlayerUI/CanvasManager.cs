using UnityEngine;
using UnityEngine.UI;


// ������ ����� �� ������ PlayerUI
public class CanvasManager : MonoBehaviour
{
    public Text PlayerInfo;                     // ���������� �� ������ (Text UI)
    private Player MyPlayer;                    // ������ this.Player
    private PlayerDamager PlayerDmgr;           // ������ this.PlayerDamager


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

    // ���������� ������ ������
    private void UpdatePlayerInfo()
    {
        PlayerInfo.text =
            $"Health : {MyPlayer.Health}\n" +
            $"Gamemode : {MyPlayer.GameMode}\n" +
            $"WeaponMode : {PlayerDmgr.WeaponMode} \n" +
            $"Weapon : - ";
    }
}
