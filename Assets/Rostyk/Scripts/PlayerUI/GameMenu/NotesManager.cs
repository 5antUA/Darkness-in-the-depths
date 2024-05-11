using UnityEngine;
using UnityEngine.UI;


// ¬≈ÿ¿“‹ — –»œ Õ¿ Œ¡⁄≈ “ TabsUI/TabNotesUI/Buttons
public class NotesManager : MonoBehaviour
{
    private SavedData.NotesData NotesData;

    [SerializeField] private Transform Notes;
    [SerializeField] private Transform Titles;


    private void Start()
    {
        NotesData = new SavedData.NotesData();
        NotesData = NotesData.Load();

        DeactivateNotes();
    }

    private void DeactivateNotes()
    {
        for (int i = 0; i < Notes.childCount; i++)
        {
            Notes.GetChild(i).GetComponent<Text>().text =
                NotesData.isActivated[i] ?
                NotesData.Notes[i] :
                "? ? ?";

            Titles.GetChild(i).GetComponent<Text>().text =
                NotesData.isActivated[i] ?
                NotesData.Titles[i] :
                "? ? ?";

            Notes.GetChild(i).gameObject.SetActive(false);
        }
    }
}
