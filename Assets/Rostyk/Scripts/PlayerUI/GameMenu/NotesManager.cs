using UnityEngine;
using UnityEngine.UI;


// Вішати на об'єкт TabsUI/TabNotesUI/Buttons
public class NotesManager : MonoBehaviour
{
    [SerializeField] private Transform Texts;           // масив всіх текстових полів для записок
    [SerializeField] private Transform Buttons;         // масив всіх кнопок іх вкладки NotesUI
    [SerializeField] private GameObject MenuUI;         // весь ігровий об'єкт MenuUI

    private Text[] _titles;                             // масив записок
    private Text[] _notes;                              // масив назв записок
    private SavedData.NotesData _notesData;             // ігрові дані про записки


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


    // Ініціалізуємо масиви та кнопки
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

    // метод оновлення даних про записки
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
