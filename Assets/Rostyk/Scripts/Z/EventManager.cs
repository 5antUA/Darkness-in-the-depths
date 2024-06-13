using System;


// сбірник всіх івентів
public class EventManager
{
    public static event Action ShowNoteNotificationEvent;       // Подія появи підказки про підняту записку
    public static event Action ShowWeaponNotificationEvent;     // Подія появи підказки про підняту зброю
    public static event Action ShowDamageScreenEvent;           // Подія появи червоного екрану при отриманні шкоди
    public static event Action OnPlayerDeathEvent;              // Подія, яка викликається при смерті персонажа

    // функкія виклику події 
    public static void ShowNoteNotification()
    {
        ShowNoteNotificationEvent?.Invoke();
    }

    // функкія виклику події 
    public static void ShowWeaponNotification()
    {
        ShowWeaponNotificationEvent?.Invoke();
    }

    // функкія виклику події 
    public static void ShowDamageScreen()
    {
        ShowDamageScreenEvent?.Invoke();
    }

    // функкія виклику події 
    public static void OnPlayerDeath()
    {
        OnPlayerDeathEvent?.Invoke();
    }
}
