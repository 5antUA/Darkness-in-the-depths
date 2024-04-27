using System.Collections;
using System.IO;
using UnityEngine;


// ������ ������ �� ������ EntryPoint
public class LoadManager : MonoBehaviour
{
    private const string PlayerDataKey = "PlayerKEY";
    private SavingToFile storage = new SavingToFile();

    private GameObject currentPlayer;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject LoadingScreen;


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        LoadGame();
        LoadingScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveGame();
        }
    }

    private void SaveGame(bool defaultParameters = false)
    {
        SavedData.PlayerData data;
        if (defaultParameters)
        {
            data = new SavedData.PlayerData();
        }
        else
        {
            Player playerProp = currentPlayer.GetComponent<Player>();
            data = new SavedData.PlayerData()
            {
                Health = playerProp.Health,
                Armor = playerProp.Armor,
                Gamemode = playerProp.GameMode,
                playerPosition = playerProp.transform.position,
                playerRotation = playerProp.transform.rotation
            };
        }
        storage.Save(PlayerDataKey, data);
    }

    private void LoadGame()
    {
        // �������� ��������� ������ �� �����
        try
        {
            SavedData.PlayerData data = new SavedData.PlayerData();
            storage.Load<SavedData.PlayerData>(PlayerDataKey, newData => data = newData);

            currentPlayer = Instantiate(player, data.playerPosition, data.playerRotation);
            currentPlayer.GetComponent<Player>().Health = data.Health;
            currentPlayer.GetComponent<Player>().Armor = data.Armor;
            currentPlayer.GetComponent<Player>().GameMode = data.Gamemode;
        }
        // ���� ����� �� ���������� ��� �� ���� �������
        catch (FileNotFoundException)
        {
            Debug.Log("Force save game");
            SaveGame(true);
            LoadGame();
        }
    }
}
