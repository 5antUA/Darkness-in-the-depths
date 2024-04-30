using System.Collections;
using UnityEngine;


// ¬≈ÿ¿“‹ — –»œ“ Õ¿ Œ¡⁄≈ “ EntryPoint
public class LoadPlayer : MonoBehaviour
{
    private SavedData.PlayerData PlayerData;

    private GameObject NewPlayer;
    [SerializeField] private GameObject PrefabPlayer;
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private Vector3 DefaultPlayerPos;


    private IEnumerator Start()
    {
        PlayerData = new SavedData.PlayerData(DefaultPlayerPos);
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
