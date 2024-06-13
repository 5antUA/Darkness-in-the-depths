using UnityEngine;


// Вішати на кожну кнопку у вкладці записок
public class NotesButtons : MonoBehaviour
{
    [SerializeField] private GameObject SelfNote;           // відкрита вкладка на даний момент
    [SerializeField] private Transform AllNotes;            // всі вкладки із довідника

    // кнопка відкриття записки
    public void AcrivateButton()
    {
        DeactivateTabs();
        SelfNote.SetActive(true);
    }

    // деактивація всіх записок
    private void DeactivateTabs()
    {
        for (int i = 0; i < AllNotes.childCount; i++)
        {
            AllNotes.GetChild(i).gameObject.SetActive(false);
        }
    }
}
