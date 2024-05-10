using UnityEngine;


// ÂÅØÀÒÜ ÑÊĞÈÏ ÍÀ ÎÁÚÅÊÒ TabsUI/MapUI/Buttons
public class MapManager : MonoBehaviour
{
    [SerializeField] private Transform Floors;
    private int floor = 2; // 3é ıòàæ, ğàñ÷åò ñ íîëÿ

    private void Start()
    {
        DeactivateMaps();
    }

    private void DeactivateMaps()
    {
        for (int i = 0; i < Floors.childCount; i++)
        {
            if (i == 2)
                break;

            Floors.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ChangeFloorRight()
    {
        if (floor == Floors.childCount - 1)
            return;

        Floors.GetChild(floor).gameObject.SetActive(false);
        floor++;
        Floors.GetChild(floor).gameObject.SetActive(true);
    }

    public void ChangeFloorLeft()
    {
        if (floor == 0)
            return;

        Floors.GetChild(floor).gameObject.SetActive(false);
        floor--;
        Floors.GetChild(floor).gameObject.SetActive(true);
    }
}
