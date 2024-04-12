using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ����� �����
// �� ������ ������ �� �������
public class Character : MonoBehaviour
{
    [Header("\t CHARACTER PROPERTIES")]
    [Space]
    public float WalkSpeed;                                    // �������� ������
    public float SprintSpeed;                                  // �������� ����
    public float CrouchSpeed;                                  // �������� ��������� ������
    public float MaxHealth;                                    // ���������� ��������
    public float Damage;                                       // ���������� �����
    public float Armor;                                        // ���������� �����

    public bool isDead => MaxHealth <= 0;                      // ���� ����

    // ������� ��� ��������� �����
    public void TakeDamage(float damage)
    {
        this.MaxHealth -= damage;
    }
}
