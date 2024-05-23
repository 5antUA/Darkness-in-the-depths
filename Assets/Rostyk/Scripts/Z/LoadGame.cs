using System.Collections;
using UnityEngine;


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ EntryPoint
public class LoadGame : MonoBehaviour
{
    private SavedData.PlayerData PlayerData;
    private SavedData.InitializationData InitializationData;

    [Header("\t Player Data")]
    [Space]
    private GameObject NewPlayer;
    private Player PlayerProperties;
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
        InitializationData = new SavedData.InitializationData();
        InitializationData = InitializationData.Load();

        // disable loading screen
        LoadPlayerData();
        SetCharacter();

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

    private void SetCharacter()
    {
        if (InitializationData.Character == RostykEnums.Characters.Kovalev)
        {
            InitializationData.CurrentCharacter = InitializationData.KovalevChar;
        }
        else if (InitializationData.Character == RostykEnums.Characters.Radchenko)
        {
            InitializationData.CurrentCharacter = InitializationData.RadchenkoChar;
        }
        else if (InitializationData.Character == RostykEnums.Characters.Valentin)
        {
            InitializationData.CurrentCharacter = InitializationData.ValentinChar;
        }

        PlayerProperties = NewPlayer.GetComponent<Player>();

        PlayerProperties.MaxCharacterHealth = InitializationData.CurrentCharacter.MaxCharacterHealth;
        PlayerProperties.Health = InitializationData.CurrentCharacter.Health;
        PlayerProperties.Damage = InitializationData.CurrentCharacter.Damage;
        PlayerProperties.WalkSpeed = InitializationData.CurrentCharacter.WalkSpeed;
        PlayerProperties.SprintSpeed = InitializationData.CurrentCharacter.SprintSpeed;
        PlayerProperties.CrouchSpeed = InitializationData.CurrentCharacter.CrouchSpeed;
    }
}
