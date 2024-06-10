using UnityEngine;
using RostykEnums;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SavedData;


// ������ ������ �� ������ EntryPoint
public class LoadGame : MonoBehaviour
{
    private CharacterData CharacterData;
    private PlayerPositionData PlayerPositionData;
    private NotesData NotesData;
    private TriggerData TriggerData;
    private InputData InputData;
    private InterfaceData InterfaceData;

    [SerializeField] private GameObject PlayerPrefab;
    public List<GameObject> TriggerList;
    private List<GameObject> CloneTriggerList;

    private GameObject PlayerCloneObject;
    private Camera PlayerCamera;
    private PlayerRotation PlayerRotation;
    private Player PlayerProperties;
    private Vector3 DefaultPlayerPosition;



    // ����� ����� ��� �������� ������ �� �����
    private void Start()
    {
        DefaultPlayerPosition = this.transform.position;
        CloneTriggerList = new();

        // init enemy data
        InitData();
        InNewGame();

        LoadPlayerPosition();
        DefineCharacter();
        LoadPlayerProperties();
        LoadTriggerData();
    }

    private void Update()
    {
        if (!PlayerProperties.IsDead)
        {
            SaveOrLoadGame();
        }
    }


    private void SaveOrLoadGame()
    {
        if (Input.GetKeyDown(InputData.SaveGame) && !PlayerProperties.IsDead)
        {
            SavePlayerPosition();
            SavePlayerProperties();
            SaveTriggerData();
        }
        else if (Input.GetKeyDown(InputData.LoadGame) && !PlayerProperties.IsDead)
        {
            SceneManager.LoadScene("LoadScene");
        }
    }

    private void InNewGame()
    {
        // ���� ������ ����� ����
        if (!CharacterData.isContinueGame)
        {
            PlayerPositionData.position = DefaultPlayerPosition;
            CharacterData.isContinueGame = true;
            CharacterData.Save();
            PlayerPositionData.Save();

            TriggerData = new(TriggerList);
            TriggerData.Save(TriggerList);
        }
    }

    private void InitData()
    {
        CharacterData = new();
        PlayerPositionData = new(DefaultPlayerPosition);
        NotesData = new();
        TriggerData = new(TriggerList);
        InputData = new();
        InterfaceData = new();

        CharacterData = CharacterData.Load();
        PlayerPositionData = PlayerPositionData.Load();
        NotesData = NotesData.Load();
        TriggerData = TriggerData.Load(TriggerList);
        InputData = InputData.Load();
        InterfaceData = InterfaceData.Load();
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
        PlayerCloneObject = Instantiate(PlayerPrefab, PlayerPositionData.position, PlayerPositionData.rotation);

        PlayerProperties = PlayerCloneObject.GetComponent<Player>();
        PlayerCamera = PlayerCloneObject.GetComponentInChildren<Camera>();
        PlayerRotation = PlayerCloneObject.GetComponentInChildren<PlayerRotation>();

        PlayerCamera.farClipPlane = InterfaceData.PlayerFar;
        PlayerRotation._sensitive =
            InterfaceData.isNegativeSensitivity ?
            -InterfaceData.CameraSensitivity :
            InterfaceData.CameraSensitivity;
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
        CharacterData.Property.LockOpeningTime = PlayerProperties.LockOpeningTime;

        CharacterData.Save();
    }

    private void SaveTriggerData()
    {
        for (int i = 0; i < TriggerList.Count; i++)
        {
            if (CloneTriggerList[i] == null)
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
                GameObject CloneTrigger = Instantiate(TriggerList[i]);
                CloneTriggerList.Add(CloneTrigger);
            }
            else
            {
                CloneTriggerList.Add(null);
            }
        }
    }
}
