using System;


public class EventManager
{
    public static event Action ShowNoteNotificationEvent;
    public static event Action ShowDamageScreenEvent;


    public static void ShowNoteNotification()
    {
        ShowNoteNotificationEvent?.Invoke();
    }

    public static void ShowDamageScreen()
    {
        ShowDamageScreenEvent?.Invoke();
    }
}
