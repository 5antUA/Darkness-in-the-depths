using UnityEngine;
using UnityEngine.UI;


public class NewNoteTrigger : MonoBehaviour
{
    SavedData.NotesData data = new SavedData.NotesData();
    private Transform Titles;
    private Transform Notes;

    private Text titleText;
    private Text noteText;

    [Range(0, 8)]
    public int NoteNumber;


    private void Awake()
    {
        Titles = GameObject.FindGameObjectWithTag("PlayerTitlesArray").transform;
        Notes = GameObject.FindGameObjectWithTag("PlayerNotesArray").transform;

        titleText = Titles.GetChild(NoteNumber).GetComponent<Text>();
        noteText = Notes.GetChild(NoteNumber).GetComponent<Text>();

        data = data.Load();
    }

    private void OnTriggerEnter(Collider other)
    {
        EventManager.ShowNotification();
        if (other.gameObject.CompareTag("Player"))
        {
            noteText.text = data.Notes[NoteNumber];
            titleText.text = data.Titles[NoteNumber];

            data.isActivated[NoteNumber] = true;
            data.Save();

            Destroy(this.gameObject);
        }
    }
}
