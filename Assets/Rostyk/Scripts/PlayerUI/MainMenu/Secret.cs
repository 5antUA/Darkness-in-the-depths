using UnityEngine;

// ? ? ?
public class Secret : MonoBehaviour
{
    private int TouchCount = 0;

    // Подсчет касаний... но для чего?
    public void OnTouch()
    {
        TouchCount++;
    }
}