using System;


public class EventManager
{
    public static event Action ShowNotificationEvent;
    public static event Action ShowPlayerRedScreenEvent;


    public static void ShowNotification()
    {
        ShowNotificationEvent?.Invoke();
    }

    public static void ShowPlayerRedScreen()
    {
        ShowPlayerRedScreenEvent?.Invoke();
    }
}
