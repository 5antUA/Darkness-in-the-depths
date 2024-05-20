using System;


public class EventManager
{
    public static event Action ShowNotificationEvent;
    public static event Action ShowDamageScreenEvent;


    public static void ShowNotification()
    {
        ShowNotificationEvent?.Invoke();
    }

    public static void ShowDamageScreen()
    {
        ShowDamageScreenEvent?.Invoke();
    }
}
