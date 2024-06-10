using UnityEngine.UI;


// ВЕШАТЬ СКРИПТ НА ПОДСКАЗКУ О ЗАПИСКАХ
public class FadeNoteNotification : FadeBase
{
    private void Start()
    {
        FadedImage = this.GetComponent<Image>();
        EventManager.ShowNoteNotificationEvent += RunFadeEffect;

        ImageColor = FadedImage.color;
        FadedImage.color = SetAlpha(0f);
    }

    private void RunFadeEffect()
    {
        StartCoroutine(FadeInCoroutine());
    }

    private void OnDisable()
    {
        EventManager.ShowNoteNotificationEvent -= RunFadeEffect;
    }
}
