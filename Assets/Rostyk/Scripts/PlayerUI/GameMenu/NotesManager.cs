using UnityEngine;
using UnityEngine.UI;


// ¬≈ÿ¿“‹ — –»œ Õ¿ Œ¡⁄≈ “ TabsUI/TabNotesUI/Buttons
public class NotesManager : MonoBehaviour
{
    private SavedData.NotesData NotesData;

    [SerializeField] private Transform Texts;
    [SerializeField] private Transform Buttons;
    [SerializeField] private GameObject MenuUI;

    private Text[] Titles;
    private Text[] Notes;


    private void Start()
    {
        NotesData = new SavedData.NotesData();
        NotesData = NotesData.Load();

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


    private void InitializeTexts()
    {
        Titles = new Text[Texts.childCount];
        Notes = new Text[Buttons.childCount];

        for (int i = 0; i < Texts.childCount; i++)
        {
            Titles[i] = Texts.GetChild(i).GetComponent<Text>();
            Notes[i] = Buttons.GetChild(i).GetComponent<Text>();
        }
    }

    private void UpdateDataUI(bool disableTexts = false)
    {
        NotesData = NotesData.Load();
        for (int i = 0; i < Buttons.childCount; i++)
        {
            Titles[i].text =
                NotesData.isActivated[i] ?
                NotesData.Notes[i] :
                "? ? ?";

            Notes[i].text =
                NotesData.isActivated[i] ?
                NotesData.Titles[i] :
                "? ? ?";

            if (disableTexts)
                Texts.GetChild(i).gameObject.SetActive(false);
        }
    }
}
