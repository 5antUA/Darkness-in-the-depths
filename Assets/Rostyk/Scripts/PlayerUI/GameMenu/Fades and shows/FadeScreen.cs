using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FadeScreen : MonoBehaviour
{
    [Range(0, 1)]
    public float normalAlpha;
    public float time;

    private Image _fadedImage;
    private Color _imageColor;


    private void Start()
    {
        _fadedImage = this.GetComponent<Image>();
        _imageColor = _fadedImage.color;
        StartCoroutine(FadeInCoroutine());
    }

    // асинхронна функція, яка керує процесом затухання UI об'єкту
    private IEnumerator FadeInCoroutine()
    {
        for (float alpha = 0.02f; alpha <= normalAlpha; alpha += 0.02f)
        {
            _fadedImage.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }

    // Функція зміни прозорості UI об'єкта
    protected Color SetAlpha(float alpha)
    {
        _imageColor.a = alpha;
        return _imageColor;
    }
}