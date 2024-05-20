using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeDamageScreen : FadeBase
{
    private void Start()
    {
        FadedImage = this.GetComponent<Image>();
        EventManager.ShowDamageScreenEvent += RunFadeEffect;

        ImageColor = FadedImage.color;
        FadedImage.color = SetAlpha(0f);
    }

    private void RunFadeEffect()
    {
        StartCoroutine(FadeInCoroutine());
        EventManager.ShowDamageScreenEvent -= RunFadeEffect;
    }
}
