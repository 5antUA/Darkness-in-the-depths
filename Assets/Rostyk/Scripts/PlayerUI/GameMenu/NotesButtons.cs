using UnityEngine;


public class NotesButtons : MonoBehaviour
{
    [SerializeField] private GameObject Tab;
    [SerializeField] private Transform Tabs;

    public void AcrivateButton()
    {
        DeactivateTabs();
        Tab.SetActive(true);
    }

    private void DeactivateTabs()
    {
        for (int i = 0; i < Tabs.childCount; i++)
        {
            Tabs.GetChild(i).gameObject.SetActive(false);
        }
    }
}
