using UnityEngine;


// ������ ������ �� ����� ������ ���� (������ ������ ShooterRay)
public class ThrowRay : MonoBehaviour
{
    // ������ ���� � ����������� ���������� �� �������, �������� ������� ���
    public RaycastHit GetHit(float distance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out RaycastHit hit, distance);
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        return hit;
    }
}
