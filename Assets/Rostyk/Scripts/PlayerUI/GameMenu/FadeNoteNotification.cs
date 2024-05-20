using UnityEngine.UI;


// ВЕШАТЬ СКРИПТ НА ПОДСКАЗКУ О ЗАПИСКАХ
public class FadeNoteNotification : FadeBase
{
    private void Start()
    {
        FadedImage = this.GetComponent<Image>();
        EventManager.ShowNotificationEvent += RunFadeEffect;

        ImageColor = FadedImage.color;
        FadedImage.color = SetAlpha(0f);
    }

    private void RunFadeEffect()
    {
        StartCoroutine(FadeInCoroutine());
        EventManager.ShowNotificationEvent -= RunFadeEffect;
    }
}
