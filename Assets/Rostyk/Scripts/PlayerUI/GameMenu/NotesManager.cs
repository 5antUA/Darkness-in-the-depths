using UnityEngine;
using UnityEngine.UI;


// ³���� �� ��'��� TabsUI/TabNotesUI/Buttons
public class NotesManager : MonoBehaviour
{
    [SerializeField] private Transform Texts;           // ����� ��� ��������� ���� ��� �������
    [SerializeField] private Transform Buttons;         // ����� ��� ������ �� ������� NotesUI
    [SerializeField] private GameObject MenuUI;         // ���� ������� ��'��� MenuUI

    private Text[] _titles;                             // ����� �������
    private Text[] _notes;                              // ����� ���� �������
    private SavedData.NotesData _notesData;             // ����� ��� ��� �������


    private void Start()
    {
        _notesData = new SavedData.NotesData();
        _notesData = _notesData.Load();
        InitializeTexts();
        UpdateDataUI(true);
    }

    private void Update()
    {
        if (MenuUI.activeInHierarchy)
        {
            UpdateDataUI();
        }
    }


    // ���������� ������ �� ������
    private void InitializeTexts()
    {
        _titles = new Text[Texts.childCount];
        _notes = new Text[Buttons.childCount];

        for (int i = 0; i < Texts.childCount; i++)
        {
            _titles[i] = Texts.GetChild(i).GetComponent<Text>();
            _notes[i] = Buttons.GetChild(i).GetComponent<Text>();
        }
    }

    // ����� ��������� ����� ��� �������
    private void UpdateDataUI(bool disableTexts = false)
    {
        _notesData = _notesData.Load();

        for (int i = 0; i < Buttons.childCount; i++)
        {
            _titles[i].text =
                _notesData.isActivated[i] ?
                _notesData.Notes[i] :
                "? ? ?";
            _notes[i].text =
                _notesData.isActivated[i] ?
                _notesData.Titles[i] :
                "? ? ?";

            if (disableTexts)
                Texts.GetChild(i).gameObject.SetActive(false);
        }
    }
}
