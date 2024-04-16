using UnityEngine;
using UnityEngine.UI;


// ������ ����� �� ������ PlayerUI
public class CanvasManager : MonoBehaviour
{
    public Text PlayerInfo;                                    // ���������� �� ������ (Text UI)
    public GameObject MenuUI;                                  // MenuUI
    private Player MyPlayer;                                   // ������ this.Player
    private PlayerDamager PlayerDmgr;                          // ������ this.PlayerDamager


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


    // ������ ��� �������� ������ �� ������
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

    // ���������� ������ ������
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
