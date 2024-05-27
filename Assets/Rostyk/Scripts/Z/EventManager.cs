using System;


public class EventManager
{
    public static event Action ShowNoteNotificationEvent;
    public static event Action ShowWeaponNotificationEvent;
    public static event Action ShowDamageScreenEvent;
    public static event Action OnPlayerDeathEvent;


    public static void ShowNoteNotification()
    {
        ShowNoteNotificationEvent?.Invoke();
    }

    public static void ShowWeaponNotification()
    {
        ShowWeaponNotificationEvent?.Invoke();
    }

    public static void ShowDamageScreen()
    {
        ShowDamageScreenEvent?.Invoke();
    }

    public static void OnPlayerDeath()
    {
        OnPlayerDeathEvent?.Invoke();
    }
}
