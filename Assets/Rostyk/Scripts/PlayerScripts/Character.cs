using UnityEngine;
using UnityEngine.AI;


// ОБЩИЙ КЛАСС
// НЕ ВЕШАТЬ СКРИПТ НА ОБЪЕКТЫ
[System.Serializable]
public class Character : MonoBehaviour
{
    [Header("\t CHARACTER PROPERTIES")]
    [Space]

    [HideInInspector]
    public float MaxCharacterHealth;                           // максимальное количество здоровья персонажа  
    public float Health;                                       // количество здоровья
    public float Damage;                                       // количество урона
    public float Armor;                                        // количество брони
    
    public float WalkSpeed;                                    // скорость ходьбы
    public float SprintSpeed;                                  // скорость бега
    public float CrouchSpeed;                                  // скорость медленной ходьбы


    public bool IsDead => Health <= 0;                         // если умер


    // Функция для получения урона
    public void TakeDamage(float damage)
    {
        this.Health -= damage;
    }
}
