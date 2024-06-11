using UnityEngine;

// Вішати скрипт на точку початку променя (ОБЪЕКТ ИГРОКА ShooterRay)
public class ThrowRay : MonoBehaviour
{
    // Викид променя та повернення інформації про перетнутий об'єкт
    public RaycastHit GetHit(float distance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out RaycastHit hit, distance);
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        return hit;
    }
}
