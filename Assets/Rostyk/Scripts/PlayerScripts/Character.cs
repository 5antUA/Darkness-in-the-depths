using UnityEngine;


// Загальний клас для всіх живих створінь
// Не вішати скріпт на GameObject
[System.Serializable]
public class Character : MonoBehaviour
{
    public float Health;                                       // кількість здоров'я
    public float Damage;                                       // кількість шкоди
    public float Armor;                                        // кількість броні
    public float WalkSpeed;                                    // скорость ходьби
    public float SprintSpeed;                                  // скорость бігу
    public float CrouchSpeed;                                  // скорость повільної ходьби

    public float MaxCharacterHealth { get; set; }              // максимальна кількість здоров'я
    public bool IsDead => Health <= 0;                         // якщо помер...


    // Функція для отримання шкоди
    public void TakeDamage(float damage)
    {
        this.Health -= damage;
    }
}
