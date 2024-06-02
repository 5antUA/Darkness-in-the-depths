using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RostykEnums;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ EntryPoint
public class LoadGame : MonoBehaviour
{
    private SavedData.CharacterData CharacterData;
    private SavedData.PlayerPositionData PlayerPositionData;
    private SavedData.NotesData NotesData;
    private SavedData.TriggerData TriggerData;

    [SerializeField] private GameObject PlayerPrefab;
    public List<GameObject> TriggerList;

    private GameObject PlayerClone;
    private Player PlayerProperties;
    private Vector3 DefaultPlayerPosition;



    // Метод старт для загрузки данных на сцене
    private void Start()
    {
        DefaultPlayerPosition = this.transform.position;

        // init player data
        InitData();
        InNewGame();

        LoadPlayerPosition();
        DefineCharacter();
        LoadPlayerProperties();
        LoadTriggerData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SavePlayerPosition();
            SavePlayerProperties();
            SaveTriggerData();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("LoadScene");
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

            TriggerData = new SavedData.TriggerData(TriggerList);
            TriggerData.Save(TriggerList);
        }
    }

    private void InitData()
    {
        CharacterData = new SavedData.CharacterData();
        PlayerPositionData = new SavedData.PlayerPositionData(DefaultPlayerPosition);
        NotesData = new SavedData.NotesData();
        TriggerData = new SavedData.TriggerData(TriggerList);

        CharacterData = CharacterData.Load();
        PlayerPositionData = PlayerPositionData.Load();
        NotesData = NotesData.Load();
        TriggerData = TriggerData.Load(TriggerList);
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
        switch (CharacterData.Character)
        {
            case Characters.Valentin:
                CharacterData.Property = CharacterData.ValentinProperty;
                break;
            case Characters.Kovalev:
                CharacterData.Property = CharacterData.KovalevProperty;
                break;
            case Characters.Romario:
                CharacterData.Property = CharacterData.RomarioProperty;
                break;
            case Characters.Panini:
                CharacterData.Property = CharacterData.PaniniProperty;
                break;
        }

        CharacterData.Save();
    }

    private void LoadPlayerProperties()
    {
        PlayerProperties.MaxCharacterHealth = CharacterData.Property.MaxCharacterHealth;
        PlayerProperties.Health = CharacterData.Property.Health;
        PlayerProperties.Damage = CharacterData.Property.Damage;
        PlayerProperties.WalkSpeed = CharacterData.Property.WalkSpeed;
        PlayerProperties.SprintSpeed = CharacterData.Property.SprintSpeed;
        PlayerProperties.CrouchSpeed = CharacterData.Property.CrouchSpeed;
        PlayerProperties.LockOpeningTime = CharacterData.Property.LockOpeningTime;
    }

    private void SavePlayerProperties()
    {
        CharacterData.Property.MaxCharacterHealth = PlayerProperties.MaxCharacterHealth;
        CharacterData.Property.Health = PlayerProperties.Health;
        CharacterData.Property.Damage = PlayerProperties.Damage;
        CharacterData.Property.WalkSpeed = PlayerProperties.WalkSpeed;
        CharacterData.Property.SprintSpeed = PlayerProperties.SprintSpeed;
        CharacterData.Property.CrouchSpeed = PlayerProperties.CrouchSpeed;
        CharacterData.Property.LockOpeningTime = PlayerProperties.LockOpeningTime;

        CharacterData.Save();
    }

    private void SaveTriggerData()
    {
        for (int i = 0; i < TriggerList.Count; i++)
        {
            if (TriggerList[i] == null)
            {
                TriggerData.IsDestroyedObject[i] = true;
            }
        }

        TriggerData.Save(TriggerList);
    }

    private void LoadTriggerData()
    {
        for (int i = 0; i < TriggerList.Count; i++)
        {
            if (!TriggerData.IsDestroyedObject[i])
            {
                Instantiate(TriggerList[i]);
            }
        }
    }

    private void DestroyOriginalTriggers()
    {

    }
}
