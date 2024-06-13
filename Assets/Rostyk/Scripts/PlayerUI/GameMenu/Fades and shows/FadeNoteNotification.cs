using UnityEngine.UI;


// Вішати скрипт на підказку про отримання записки
public class FadeNoteNotification : FadeBase
{
    private void Start()
    {
        _fadedImage = this.GetComponent<Image>();
        EventManager.ShowNoteNotificationEvent += RunFadeEffect; // підписуємося на івент
        _imageColor = _fadedImage.color;
        _fadedImage.color = SetAlpha(0f);
    }

    // функція, яка запускає процес спалаху
    private void RunFadeEffect()
    {
        StartCoroutine(FadeInCoroutine());
    }

    // на кінці життя об'єкта відписуємося від івента
    private void OnDisable()
    {
        EventManager.ShowNoteNotificationEvent -= RunFadeEffect;
    }
}
