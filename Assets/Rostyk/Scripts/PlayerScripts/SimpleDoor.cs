using UnityEngine;


public class SimpleDoor : MonoBehaviour
{
    private Animator anim;                  // Аніматор для керування анімаціями дверей
    public float distance;                  // Дистанція взаємодії з дверима
    public bool isOpen { get; set; }        // Властивість для перевірки, чи двері відкриті

    void Start()
    {
        anim = GetComponent<Animator>();    // Отримання посилання на компонент Animator
        isOpen = false;                     // Ініціалізація стану дверей як закриті
    }

    // Метод для відкриття дверей
    public void Open()
    {
        anim.SetBool("isOpen", true);       // Встановлення параметра аніматора для відкриття дверей
        isOpen = true;                      // Оновлення стану дверей як відкриті
    }

    // Метод для закриття дверей
    public void Close()
    {
        anim.SetBool("isOpen", false);      // Встановлення параметра аніматора для закриття дверей
        isOpen = false;                     // Оновлення стану дверей як закриті
    }
}
