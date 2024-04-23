using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ОБЩИЙ КЛАСС
// НЕ ВЕШАТЬ СКРИПТ НА ОБЪЕКТЫ
public class Character : MonoBehaviour
{
    [Header("\t CHARACTER PROPERTIES")]
    [Space]
    public float WalkSpeed;                                    // скорость ходьбы
    public float SprintSpeed;                                  // скорость бега
    public float CrouchSpeed;                                  // скорость медленной ходьбы

    public float Health;                                       // количество здоровья
    public float Damage;                                       // количество урона
    public float Armor;                                        // количество брони

    public bool isDead => Health <= 0;                         // если умер

    // Функция для получения урона
    public void TakeDamage(float damage)
    {
        this.Health -= damage;
    }
}
