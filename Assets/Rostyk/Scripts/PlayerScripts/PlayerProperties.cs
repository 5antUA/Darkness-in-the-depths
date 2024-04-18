using RostykEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProperties", menuName = "Properties/PlayerProperties")]
public class PlayerProperties : ScriptableObject
{
    public float WalkSpeed;                                    // скорость ходьбы
    public float SprintSpeed;                                  // скорость бега
    public float CrouchSpeed;                                  // скорость медленной ходьбы
    public float FlySpeed;                                     // скорость полета (режим креатива)

    [Space]
    public float Health;                                       // количество здоровья
    public float Damage;                                       // количество урона
    public float Armor;                                        // количество брони

    [Space]
    public Gamemode GameMode;                                  // игровой режим
    public float CrouchHeight;                                 // Высота прыседания
    public float JumpForce;                                    // сила прыжка
}
