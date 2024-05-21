using System.Collections;
using UnityEngine;


// ������ ������ �� ������ EntryPoint
public class LoadGame : MonoBehaviour
{
    private SavedData.PlayerData PlayerData;
    private SavedData.CharacterData CharacterData;

    [Header("\t Player Data")]
    [Space]
    private GameObject NewPlayer;
    [SerializeField] private GameObject[] PrefabsPlayer;
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private Vector3 DefaultPlayerPos;


    // ����������� ����� ����� ��� �������� ������ �� �����
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        // init player data
        PlayerData = new SavedData.PlayerData(DefaultPlayerPos);
        PlayerData = PlayerData.Load();
        CharacterData = new SavedData.CharacterData();
        CharacterData = CharacterData.Load();

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
        for (int i = 0; i < CharacterData.character.Length; i++)
        {
            if (CharacterData.character[i])
            {
                NewPlayer = Instantiate(PrefabsPlayer[0], PlayerData.position, PlayerData.rotation);
                break;
            }
        }
    }
}
