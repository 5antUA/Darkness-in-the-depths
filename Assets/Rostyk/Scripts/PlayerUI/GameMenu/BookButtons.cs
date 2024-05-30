using UnityEngine;


public class BookButtons : MonoBehaviour
{
    [SerializeField] private GameObject SelfGameObject;
    [SerializeField] private Transform AllTabs;

    public void ActivateButton()
    {
        DeactivateTabs();
        SelfGameObject.SetActive(true);
    }

    private void DeactivateTabs()
    {
        for (int i = 0; i < AllTabs.childCount; i++)
        {
            AllTabs.GetChild(i).gameObject.SetActive(false);
        }
    }
}