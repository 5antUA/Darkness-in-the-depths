using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButtonsManager : MonoBehaviour
{
    [SerializeField] private Button TabDevButton;
    [SerializeField] private Button TabInventoryButton;
    [SerializeField] private Button TabNotesButton;
    [SerializeField] private Button TabMapButton;
    [SerializeField] private Button TabSettingsButton;

    [SerializeField] private Transform TabsUI;
    private GameObject[] tabs;

    private void Start()
    {
        for (int i = 0; i < TabsUI.transform.childCount; )
        {

        }
    }

    private void Sho()
    {
        TabsUI.transform.GetChild(2);
    }
}
