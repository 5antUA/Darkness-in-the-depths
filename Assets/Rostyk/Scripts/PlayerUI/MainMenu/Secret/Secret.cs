using UnityEngine;

// ? ? ?
public class Secret : MonoBehaviour
{
    private int counter = 0;
    public int TouchCount
    {
        get
        {
            return counter;
        }
        private set
        {
            counter = value;
        }
    }

    // підрахунок кліків... але для чого?
    public void OnTouch()
    {
        TouchCount++;
    }
}