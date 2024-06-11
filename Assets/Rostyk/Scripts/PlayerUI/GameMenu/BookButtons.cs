using UnityEngine;


public class BookButtons : MonoBehaviour
{
    [SerializeField] private GameObject SelfGameObject;     // відкрита вкладка на даний момент
    [SerializeField] private Transform AllTabs;             // всі вкладки із довідника

    // функція активації вкладки із довідника
    public void ActivateButton()
    {
        DeactivateTabs();
        SelfGameObject.SetActive(true);
    }

    // функція деактивації вкладки із довідника
    private void DeactivateTabs()
    {
        for (int i = 0; i < AllTabs.childCount; i++)
        {
            AllTabs.GetChild(i).gameObject.SetActive(false);
        }
    }
}