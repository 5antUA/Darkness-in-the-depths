using SavedData;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterButtons : MonoBehaviour
{
    private CharacterData CharacterData;
    private PlayerPositionData PlayerData;
    private NotesData NotesData;
    private RostykEnums.Characters character;
    private string CharacterName;

    [SerializeField] private GameObject BlackImage;
    [SerializeField] private GameObject ConfirmScreenUI;

    void Start()
    {
        CharacterData = new CharacterData();
        PlayerData = new PlayerPositionData();
        NotesData = new NotesData();
    }


    public void SetCharacterValentinButton()
    {
        character = RostykEnums.Characters.Valentin;
        CharacterName = "Валентин";
    }

    public void SetCharacterKovalButton()
    {
        character = RostykEnums.Characters.Kovalev;
        CharacterName = "Владіслейв";
    }

    public void SetCharacterRomarioButton()
    {
        character = RostykEnums.Characters.Romario;
        CharacterName = "Ромаріо Десантес";
    }

    public void SetCharacterPaniniButton()
    {
        character = RostykEnums.Characters.Panini;
        CharacterName = "Містер Бігуді";
    }

    public void ApplyCharacterButton()
    {
        ConfirmScreenUI.SetActive(true);
        ConfirmScreenUI.GetComponentInChildren<Text>().text =
            $"Ви дійсно хочете обрати персонажа {CharacterName}?";
    }

    public void ApplyCharacterButtonYes()
    {
        ConfirmScreenUI.SetActive(false);
        BlackImage.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(LoadGame());

        CharacterData.isContinueGame = false;
        CharacterData.Character = character;
        CharacterData.Save();
        PlayerData.Save();
        NotesData.Save();
    }

    public void ApplyCharacterButtonNo()
    {
        ConfirmScreenUI.SetActive(false);
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("LoadScene");
    }
}
