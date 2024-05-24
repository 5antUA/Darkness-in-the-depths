using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RostykEnums;


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ EntryPoint
public class LoadGame : MonoBehaviour
{
    private SavedData.CharacterData CharacterData;
    private SavedData.PlayerPositionData PlayerPositionData;
    private SavedData.NotesData NotesData;

    private GameObject PlayerClone;
    private Player PlayerProperties;
    private Vector3 DefaultPlayerPosition;

    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject LoadingScreen;


    // Асинхронный метод старт для загрузки данных на сцене
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        DefaultPlayerPosition = this.transform.position;

        // init player data
        InitData();
        InNewGame();

        LoadPlayerPosition();
        DefineCharacter();
        LoadPlayerProperties();

        LoadingScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SavePlayerPosition();
            SavePlayerProperties();
        }
    }


    private void InNewGame()
    {
        // если начата новая игра
        if (!CharacterData.isContinueGame)
        {
            PlayerPositionData.position = DefaultPlayerPosition;
            CharacterData.isContinueGame = true;
            CharacterData.Save();
            PlayerPositionData.Save();
        }
    }

    private void InitData()
    {
        CharacterData = new SavedData.CharacterData();
        PlayerPositionData = new SavedData.PlayerPositionData(DefaultPlayerPosition);
        NotesData = new SavedData.NotesData();

        CharacterData = CharacterData.Load();
        PlayerPositionData = PlayerPositionData.Load();
        NotesData = NotesData.Load();
    }

    private void SavePlayerPosition()
    {
        PlayerPositionData = new SavedData.PlayerPositionData()
        {
            position = PlayerProperties.transform.position,
            rotation = PlayerProperties.transform.rotation
        };

        PlayerPositionData.Save();
    }

    private void LoadPlayerPosition()
    {
        PlayerClone = Instantiate(PlayerPrefab, PlayerPositionData.position, PlayerPositionData.rotation);
        PlayerProperties = PlayerClone.GetComponent<Player>();
    }

    private void DefineCharacter()
    {
        if (CharacterData.Character == Characters.Kovalev)
        {
            CharacterData.Property = CharacterData.KovalevProperty;
        }
        else if (CharacterData.Character == Characters.Radchenko)
        {
            CharacterData.Property = CharacterData.RadchenkoProperty;
        }
        else if (CharacterData.Character == Characters.Valentin)
        {
            CharacterData.Property = CharacterData.ValentinProperty;
        }
    }

    private void LoadPlayerProperties()
    {
        PlayerProperties.MaxCharacterHealth = CharacterData.Property.MaxCharacterHealth;
        PlayerProperties.Health = CharacterData.Property.Health;
        PlayerProperties.Damage = CharacterData.Property.Damage;
        PlayerProperties.WalkSpeed = CharacterData.Property.WalkSpeed;
        PlayerProperties.SprintSpeed = CharacterData.Property.SprintSpeed;
        PlayerProperties.CrouchSpeed = CharacterData.Property.CrouchSpeed;
    }

    private void SavePlayerProperties()
    {
        CharacterData.Property.MaxCharacterHealth = PlayerProperties.MaxCharacterHealth;
        CharacterData.Property.Health = PlayerProperties.Health;
        CharacterData.Property.Damage = PlayerProperties.Damage;
        CharacterData.Property.WalkSpeed = PlayerProperties.WalkSpeed;
        CharacterData.Property.SprintSpeed = PlayerProperties.SprintSpeed;
        CharacterData.Property.CrouchSpeed = PlayerProperties.CrouchSpeed;

        CharacterData.Save();
    }
}
