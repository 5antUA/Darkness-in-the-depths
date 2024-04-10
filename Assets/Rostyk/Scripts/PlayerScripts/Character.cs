using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ОБЩИЙ КЛАСС
public class Character : MonoBehaviour
{

    [Header("\t CHARACTER PROPERTIES")]
    [Space]
    public float WalkSpeed;                                    // скорость ходьбы
    public float SprintSpeed;                                  // скорость бега
    public float MaxHealth;                                    // здоровье игрока
    public float Damage;
    public float Armor;                                        // количество брони

    public bool isDead => MaxHealth <= 0;                      // если умер


    public void TakeDamage(float damage)
    {
        this.MaxHealth -= damage;
    }
}
