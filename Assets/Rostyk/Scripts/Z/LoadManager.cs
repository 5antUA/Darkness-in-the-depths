using System.Collections;
using System.IO;
using UnityEngine;


// ¬≈ÿ¿“‹ — –»œ“ Õ¿ Œ¡⁄≈ “ EntryPoint
public class LoadManager : MonoBehaviour
{
    private SavedData.PlayerData PlayerData;

    private GameObject NewPlayer;
    [SerializeField] private GameObject PrefabPlayer;
    [SerializeField] private GameObject LoadingScreen;


    private IEnumerator Start()
    {
        PlayerData = new SavedData.PlayerData();
        PlayerData = PlayerData.Load();
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

    private void LoadGame()
    {
        NewPlayer = Instantiate(PrefabPlayer, PlayerData.position, PlayerData.rotation);
    }
}
