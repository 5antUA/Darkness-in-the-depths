using System;


public class EventManager
{
    public static event Action ShowNotificationEvent;


    public static void ShowNotification()
    {
        ShowNotificationEvent?.Invoke();
    }
}
