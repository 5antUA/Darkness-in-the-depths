using SavedData;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharacterButtons : MonoBehaviour
{
    [SerializeField] private GameObject BlackImage;              // напівпрозорий чорний екран
    [SerializeField] private GameObject ConfirmScreenUI;         // UI елемент (підтвердження дії)

    private string CharacterName;                                // ім'я персонажа
    private CharacterData CharacterData;                         // ігрові дані про персонажа
    private PlayerPositionData PlayerData;                       // ігрові дані про гравця
    private NotesData NotesData;                                 // ігрові дані про записки
    private RostykEnums.Characters character;                    // обраний персонаж


    void Start()
    {
        CharacterData = new CharacterData();
        PlayerData = new PlayerPositionData();
        NotesData = new NotesData();
    }


    // кнопка вибору персонажа Валентин
    public void SetCharacterValentinButton()
    {
        character = RostykEnums.Characters.Valentin;
        CharacterName = "Валентин";
    }

    // кнопка вибору персонажа Владіслейв
    public void SetCharacterKovalButton()
    {
        character = RostykEnums.Characters.Kovalev;
        CharacterName = "Владіслейв";
    }

    // кнопка вибору персонажа Ромаріо Десантес
    public void SetCharacterRomarioButton()
    {
        character = RostykEnums.Characters.Romario;
        CharacterName = "Ромаріо Десантес";
    }

    // кнопка вибору персонажа Містер Бігуді
    public void SetCharacterPaniniButton()
    {
        character = RostykEnums.Characters.Panini;
        CharacterName = "Містер Бігуді";
    }

    // кнопка вибору персонажа
    public void ApplyCharacterButton()
    {
        ConfirmScreenUI.SetActive(true);
        ConfirmScreenUI.GetComponentInChildren<Text>().text =
            $"Ви дійсно хочете обрати персонажа {CharacterName}?";
    }

    // кнопка "Так" в підтвердженні вибору персонажа
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

    // кнопка "Ні" в підтвердженні вибору персонажа
    public void ApplyCharacterButtonNo()
    {
        ConfirmScreenUI.SetActive(false);
    }

    // асинхронна функція запуску екрана загрузки
    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("LoadScene");
    }
}
