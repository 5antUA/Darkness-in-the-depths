using RostykEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProperties", menuName = "Properties/PlayerProperties")]
public class PlayerProperties : ScriptableObject
{
    public float WalkSpeed;                                    // �������� ������
    public float SprintSpeed;                                  // �������� ����
    public float CrouchSpeed;                                  // �������� ��������� ������
    public float FlySpeed;                                     // �������� ������ (����� ��������)

    [Space]
    public float Health;                                       // ���������� ��������
    public float Damage;                                       // ���������� �����
    public float Armor;                                        // ���������� �����

    [Space]
    public Gamemode GameMode;                                  // ������� �����
    public float CrouchHeight;                                 // ������ ����������
    public float JumpForce;                                    // ���� ������
}
