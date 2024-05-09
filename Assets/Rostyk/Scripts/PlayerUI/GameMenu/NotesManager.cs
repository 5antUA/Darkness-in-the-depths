using UnityEngine;
using UnityEngine.UI;

public class NotesManager : MonoBehaviour
{
    private SavedData.NotesData NotesData;

    [SerializeField] private Transform Notes;
    [SerializeField] private Transform Titles;


    private void Start()
    {
        NotesData = new SavedData.NotesData();
        NotesData = NotesData.Load();

        DeactivateTabs();
    }

    private void DeactivateTabs()
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
