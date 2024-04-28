using System.Collections;
using System.IO;
using UnityEngine;


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ EntryPoint
public class LoadManager : MonoBehaviour
{
    private const string PlayerDataKey = "PlayerKEY";

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
        StorageService.Save(PlayerDataKey, data);
    }

    private void LoadGame()
    {
        // пытаемся загрузить данные из файла
        try
        {
            var data = StorageService.Load<SavedData.PlayerData>(PlayerDataKey);

            currentPlayer = Instantiate(player, data.playerPosition, data.playerRotation);
            currentPlayer.GetComponent<Player>().Health = data.Health;
            currentPlayer.GetComponent<Player>().Armor = data.Armor;
            currentPlayer.GetComponent<Player>().GameMode = data.Gamemode;
        }
        // если файла не существует или не было найдено, то записываем данные по умолчанию
        catch (FileNotFoundException)
        {
            Debug.Log("Force save game");
            SaveGame(true);
            LoadGame();
        }
    }
}
