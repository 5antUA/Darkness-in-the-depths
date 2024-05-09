using UnityEngine;


public class NotesButtons : MonoBehaviour
{
    [SerializeField] private GameObject SelfNote;
    [SerializeField] private Transform AllNotes;

    public void AcrivateButton()
    {
        DeactivateTabs();
        SelfNote.SetActive(true);
    }

    private void DeactivateTabs()
    {
        for (int i = 0; i < AllNotes.childCount; i++)
        {
            AllNotes.GetChild(i).gameObject.SetActive(false);
        }
    }
}
