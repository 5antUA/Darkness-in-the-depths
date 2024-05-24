using System.Collections;
using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ EntryPoint
public class LoadGame : MonoBehaviour
{
    private SavedData.InitializationData InitializationData;
    private SavedData.PlayerData PlayerData;
    private SavedData.NotesData NotesData;

    [Header("\t Player Data")]
    [Space]
    private GameObject NewPlayer;
    private Player PlayerProperties;
    [SerializeField] private GameObject PrefabPlayer;
    [SerializeField] private GameObject LoadingScreen;

    private Vector3 DefaultPlayerPos;
    


    // Асинхронный метод старт для загрузки данных на сцене
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        DefaultPlayerPos = this.transform.position;

        // init player data
        InitData();
        if (!InitializationData.isContinueGame)
        {
            PlayerData.position = DefaultPlayerPos;
            InitializationData.isContinueGame = true;
            InitializationData.Save();
            PlayerData.Save();
        }

        LoadPlayerData();
        SetCharacter();
        SetCharacterProperties();

        LoadingScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveGame();
        }
    }

    private void InitData()
    {
        InitializationData = new SavedData.InitializationData();
        PlayerData = new SavedData.PlayerData(DefaultPlayerPos);
        NotesData = new SavedData.NotesData();

        InitializationData = InitializationData.Load();
        PlayerData = PlayerData.Load();
        NotesData = NotesData.Load();
    }

    private void SaveGame()
    {
        Player player = NewPlayer.GetComponent<Player>();

        PlayerData = new SavedData.PlayerData()
        {
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
    }

    private void SetCharacterProperties()
    {
        PlayerProperties = NewPlayer.GetComponent<Player>();

        PlayerProperties.MaxCharacterHealth = InitializationData.CurrentCharacter.MaxCharacterHealth;
        PlayerProperties.Health = InitializationData.CurrentCharacter.Health;
        PlayerProperties.Damage = InitializationData.CurrentCharacter.Damage;
        PlayerProperties.WalkSpeed = InitializationData.CurrentCharacter.WalkSpeed;
        PlayerProperties.SprintSpeed = InitializationData.CurrentCharacter.SprintSpeed;
        PlayerProperties.CrouchSpeed = InitializationData.CurrentCharacter.CrouchSpeed;
    }
}
