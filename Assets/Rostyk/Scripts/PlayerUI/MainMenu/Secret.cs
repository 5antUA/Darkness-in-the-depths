using UnityEngine;

// ? ? ?
public class Secret : MonoBehaviour
{
    private int TouchCount = 0;

    // ������� �������... �� ��� ����?
    public void OnTouch()
    {
        TouchCount++;
    }
}