using UnityEngine;
using UnityEngine.UI;

public class TRIGGER : MonoBehaviour
{
    SavedData.NotesData data = new SavedData.NotesData();
    [SerializeField] private Text noteText;
    [SerializeField] private Text titleText;

    private void Start()
    {
        data = data.Load();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            noteText.text = data.Notes[0];
            titleText.text = data.Titles[0];

            data.isActivated[0] = true;
            data.Save();

            Destroy(this.gameObject);
        }
    }
}
