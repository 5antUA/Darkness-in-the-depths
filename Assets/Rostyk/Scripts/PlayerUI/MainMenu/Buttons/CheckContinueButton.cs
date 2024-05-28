using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckContinueButton : MonoBehaviour
{
    SavedData.CharacterData initializationData;
    private Button theButton;

    private void Awake()
    {
        initializationData = new SavedData.CharacterData();
        initializationData = initializationData.Load();

        theButton = this.GetComponent<Button>();
        if (initializationData.isContinueGame)
            theButton.interactable = true;
    }
}
