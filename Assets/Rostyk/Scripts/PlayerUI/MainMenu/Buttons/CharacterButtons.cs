using SavedData;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterButtons : MonoBehaviour
{
    private CharacterData InitializationData;
    private RostykEnums.Characters character;


    void Start()
    {
        InitializationData = new CharacterData();
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
        InitializationData.isContinueGame = false;
        InitializationData.Character = character;

        InitializationData.Save();

        SceneManager.LoadScene("RostykScene");
    }
}
