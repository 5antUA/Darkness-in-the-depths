using UnityEngine;


// Вішати скрипт на об'єкт TabsUI/MapUI/Buttons
public class MapManager : MonoBehaviour
{
    [SerializeField] private Transform Floors;      // масив UI елементів
    private int floor = 2;                          // поверх по замовчуванню (3й, відлік з нуля)

    private void Start()
    {
        DeactivateMaps();
    }

    // деактивація всіх дочерніх об'єктів в MapsUI
    private void DeactivateMaps()
    {
        for (int i = 0; i < Floors.childCount; i++)
        {
            if (i == 2)
                break;

            Floors.GetChild(i).gameObject.SetActive(false);
        }
    }

    // кнопка зміни поверху (своп направо)
    public void ChangeFloorRight()
    {
        if (floor == Floors.childCount - 1)
            return;

        Floors.GetChild(floor).gameObject.SetActive(false);
        floor++;
        Floors.GetChild(floor).gameObject.SetActive(true);
    }

    // кнопка зміни поверху (своп наліво)
    public void ChangeFloorLeft()
    {
        if (floor == 0)
            return;

        Floors.GetChild(floor).gameObject.SetActive(false);
        floor--;
        Floors.GetChild(floor).gameObject.SetActive(true);
    }
}
