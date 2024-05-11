using System.Collections;
using UnityEngine;


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ EntryPoint
public class LoadGame : MonoBehaviour
{
    private SavedData.PlayerData PlayerData;

    [Header("\t Player Data")]
    [Space]
    private GameObject NewPlayer;
    [SerializeField] private GameObject PrefabPlayer;
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private Vector3 DefaultPlayerPos;


    // Асинхронный метод старт для загрузки данных на сцене
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        // init player data
        PlayerData = new SavedData.PlayerData(DefaultPlayerPos);
        PlayerData = PlayerData.Load();

        // disable loading screen
        LoadPlayerData();

        LoadingScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveGame();
        }
    }

    private void SaveGame()
    {
        Player player = NewPlayer.GetComponent<Player>();

        PlayerData = new SavedData.PlayerData()
        {
            Health = player.Health,
            Armor = player.Armor,
            Gamemode = player.GameMode,
            position = player.transform.position,
            rotation = player.transform.rotation
        };

        PlayerData.Save();
    }

    private void LoadPlayerData()
    {
        NewPlayer = Instantiate(PrefabPlayer, PlayerData.position, PlayerData.rotation);

    }
}
