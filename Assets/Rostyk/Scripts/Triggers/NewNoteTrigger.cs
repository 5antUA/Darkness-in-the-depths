using UnityEngine;
using UnityEngine.UI;


public class NewNoteTrigger : MonoBehaviour
{
    SavedData.NotesData data;

    [Range(0, 7)]
    public int NoteNumber;


    private void Start()
    {
        data = new SavedData.NotesData();
        data = data.Load();
    }

    private void OnTriggerEnter(Collider other)
    {
        EventManager.ShowNotification();
        if (other.gameObject.CompareTag("Player"))
        {
            data.isActivated[NoteNumber] = true;
            data.Save();

            Destroy(this.gameObject);
        }
    }
}
