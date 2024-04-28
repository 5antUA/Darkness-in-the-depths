using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// ������ ����� �� ������ PlayerUI
public class CanvasManager : MonoBehaviour
{
    private SavedData.InputData InputData;

    public Text PlayerInfo;                                    // ���������� �� ������ (Text UI)
    public GameObject MenuUI;                                  // MenuUI
    private Player MyPlayer;                                   // ������ this.Player
    private PlayerDamager PlayerDmgr;                          // ������ this.PlayerDamager


    private void Awake()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();
    }
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
        if (Input.GetKeyDown(InputData.Info) && PlayerInfo.enabled == true)
        {
            PlayerInfo.enabled = false;
        }
        else if (Input.GetKeyDown(InputData.Info) && PlayerInfo.enabled == false)
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

    public void BackButton()
    {
        SceneManager.LoadScene("Main menu");
    }
}
