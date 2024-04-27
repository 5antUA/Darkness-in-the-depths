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

    // Подсчет касаний... но для чего?
    public void OnTouch()
    {
        TouchCount++;
    }
}