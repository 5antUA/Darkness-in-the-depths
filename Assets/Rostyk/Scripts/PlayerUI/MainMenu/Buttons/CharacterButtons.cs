using SavedData;
using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        
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
        SavedData.PlayerData playerData = new SavedData.PlayerData();
        SavedData.NotesData notesData = new SavedData.NotesData();
        InitializationData.isContinueGame = true;
        InitializationData.Character = character;

        playerData.Save();
        notesData.Save();
        InitializationData.Save();

        SceneManager.LoadScene("RostykScene");
    }
}
