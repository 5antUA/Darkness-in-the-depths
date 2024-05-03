using UnityEngine;
using UnityEngine.AI;


// ����� �����
// �� ������ ������ �� �������
public class Character : MonoBehaviour
{
    [Header("\t CHARACTER PROPERTIES")]
    [Space]
    public float WalkSpeed;                                    // �������� ������
    public float SprintSpeed;                                  // �������� ����
    public float CrouchSpeed;                                  // �������� ��������� ������

    public float Health;                                       // ���������� ��������
    public float Damage;                                       // ���������� �����
    public float Armor;                                        // ���������� �����

    public bool IsDead => Health <= 0;                         // ���� ����

    // ������� ��� ��������� �����
    public void TakeDamage(float damage)
    {
        this.Health -= damage;
    }
}
