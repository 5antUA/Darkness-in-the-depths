using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesManager : MonoBehaviour
{
    [SerializeField] private Transform Tabs;
    private SavedData.NotesData NotesData;

    private void Start()
    {
        NotesData = new SavedData.NotesData();
        NotesData = NotesData.Load();

        DeactivateTabs();
    }

    private void DeactivateTabs()
    {
        for (int i = 0; i < Tabs.childCount; i++)
        {
            Tabs.GetChild(i).GetComponent<Text>().text =
                NotesData.isActivated[i] ?
                NotesData.Notes[i] :
                "? ? ?";

            Tabs.GetChild(i).gameObject.SetActive(false);
        }
    }
}
