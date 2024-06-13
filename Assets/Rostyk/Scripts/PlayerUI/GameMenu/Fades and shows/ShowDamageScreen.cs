using UnityEngine.UI;


public class ShowDamageScreen : FadeBase
{
    private void Start()
    {
        _fadedImage = this.GetComponent<Image>();
        EventManager.ShowDamageScreenEvent += RunFadeEffect; // підписуємося на івент
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
        EventManager.ShowDamageScreenEvent -= RunFadeEffect;
    }
}
