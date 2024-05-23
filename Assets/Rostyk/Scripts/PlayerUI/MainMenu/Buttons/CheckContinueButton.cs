using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckContinueButton : MonoBehaviour
{
    SavedData.InitializationData initializationData;
    private Button theButton;

    private void Start()
    {
        initializationData = new SavedData.InitializationData();
        initializationData = initializationData.Load();

        theButton = this.GetComponent<Button>();
        if (initializationData.isContinueGame)
            theButton.interactable = true;
    }
}
