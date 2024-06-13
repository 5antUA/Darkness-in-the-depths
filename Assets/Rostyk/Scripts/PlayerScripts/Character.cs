using UnityEngine;


// ��������� ���� ��� ��� ����� �������
// �� ����� ����� �� GameObject
[System.Serializable]
public class Character : MonoBehaviour
{
    public float Health;                                       // ������� ������'�
    public float Damage;                                       // ������� �����
    public float Armor;                                        // ������� ����
    public float WalkSpeed;                                    // �������� ������
    public float SprintSpeed;                                  // �������� ���
    public float CrouchSpeed;                                  // �������� ������� ������

    public float MaxCharacterHealth { get; set; }              // ����������� ������� ������'�
    public bool IsDead => Health <= 0;                         // ���� �����...


    // ������� ��� ��������� �����
    public void TakeDamage(float damage)
    {
        this.Health -= damage;
    }
}
