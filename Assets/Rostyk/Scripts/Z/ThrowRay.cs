using UnityEngine;


// ВЕШАТЬ СКРИПТ НА ТОЧКУ НАЧАЛА ЛУЧА (ОБЪЕКТ ИГРОКА ShooterRay)
public class ThrowRay : MonoBehaviour
{
    // Бросок луча и возвращение информации об объекте, которого пересек луч
    public RaycastHit GetHit(float distance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out RaycastHit hit, distance);
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        return hit;
    }
}
