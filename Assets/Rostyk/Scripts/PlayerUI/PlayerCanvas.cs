using UnityEngine;
using UnityEngine.UI;


// ������ ����� �� ������ PlayerUI
public class PlayerCanvas : MonoBehaviour
{
    public Text PlayerInfo;
    protected Player MyPlayer;
    private PlayerDamager PlayerDmgr;


    private void Start()
    {
        MyPlayer = GetComponentInParent<Player>();
        PlayerDmgr = GetComponentInParent<PlayerDamager>();
    }

    private void Update()
    {
        if (PlayerInfo != null)
            UpdatePlayerInfo();
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
