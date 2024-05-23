using SavedData;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterButtons : MonoBehaviour
{
    private InitializationData InitializationData;
    private RostykEnums.Characters character;


    void Start()
    {
        InitializationData = new InitializationData();
    }


    public void SetCharacterKovalButton()
    {
        character = RostykEnums.Characters.Kovalev;
    }


    public void SetCharacterRadchenkoButton()
    {
        character = RostykEnums.Characters.Radchenko;
    }

    public void SetCharacterValentinButton()
    {
        character = RostykEnums.Characters.Valentin;
    }

    public void ApplyCharacterButton()
    {
        InitializationData.isContinueGame = false;
        InitializationData.Character = character;

        InitializationData.Save();

        SceneManager.LoadScene("RostykScene");
    }
}
