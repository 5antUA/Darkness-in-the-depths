using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FadeMenuDeathScreen : MonoBehaviour
{
    [Range(0, 1)]
    public float normalAlpha;
    public float time;

    private Image FadedImage;
    private Color ImageColor;


    private void Start()
    {
        FadedImage = this.GetComponent<Image>();
        EventManager.ShowMenuDeathScreenEvent += RunFadeEffect;

        ImageColor = FadedImage.color;
        FadedImage.color = SetAlpha(0f);
        EventManager.ShowMenuDeathScreen();
    }

    private void RunFadeEffect()
    {
        StartCoroutine(FadeInCoroutine());
    }

    private void OnDisable()
    {
        EventManager.ShowMenuDeathScreenEvent -= RunFadeEffect;
    }

    private IEnumerator FadeInCoroutine()
    {
        for (float alpha = 0.02f; alpha <= normalAlpha; alpha += 0.02f)
        {
            FadedImage.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }

    protected Color SetAlpha(float alpha)
    {
        ImageColor.a = alpha;
        return ImageColor;
    }
}