using RostykEnums;
using UnityEngine;


// Загрузчик MenuUI
public class LoadMenuUI : MonoBehaviour
{
    [SerializeField] private Transform TabsUI;                  // список (массив) объектов UI из вкладки AllTabs
    private TabMenu MyTab;                                      // выбраная вкладка сейчас


    private void Start()
    {
        // в начале игры выбрана данная вкладка
        MyTab = TabMenu.Inventory;

        // через цикл деактивируем елементы UI из остальных вкладок
        for (int i = 0; i < TabsUI.childCount; i++)
        {
            if ((int)MyTab == i)
                continue;

            TabsUI.GetChild(i).gameObject.SetActive(false);
        }
    }
}
