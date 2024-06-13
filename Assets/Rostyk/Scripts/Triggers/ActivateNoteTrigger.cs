using UnityEngine;


public class ActivateNoteTrigger : MonoBehaviour
{
    SavedData.NotesData data;

    [Range(0, 7)]
    public int NoteNumber;


    private void Start()
    {
        data = new SavedData.NotesData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            data = data.Load();
            EventManager.ShowNoteNotification();
            data.isActivated[NoteNumber] = true;
            data.Save();

            Destroy(this.gameObject);
        }
    }
}
