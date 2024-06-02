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

    [SerializeField] private GameObject BlackImage;
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private Image Skull;

    void Start()
    {
        CharacterData = new CharacterData();
        PlayerData = new PlayerPositionData();
        NotesData = new NotesData();
    }


    public void SetCharacterValentinButton()
    {
        character = RostykEnums.Characters.Valentin;
    }


    public void SetCharacterKovalButton()
    {
        character = RostykEnums.Characters.Kovalev;
    }

    public void SetCharacterRomarioButton()
    {
        character = RostykEnums.Characters.Romario;
    }

    public void SetCharacterPaniniButton()
    {
        character = RostykEnums.Characters.Panini;
    }

    public void ApplyCharacterButton()
    {
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

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3f);

        LoadingScreen.SetActive(true);
        AsyncOperation LoadAsync = SceneManager.LoadSceneAsync("RostykScene");
        while (!LoadAsync.isDone)
        {
            Skull.fillAmount = LoadAsync.progress;
            yield return null;
        }
    }
}
