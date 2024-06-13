using System.Collections;
using UnityEngine;
using UnityEngine.UI;


// базовий абстрактний клас, який реалізує спалах UI елементів
public abstract class FadeBase : MonoBehaviour
{
    public float normalAlpha = 1f;
    [Space]
    public float startTime;
    public float betweenTime;
    public float endTime;

    protected Image _fadedImage;
    protected Color _imageColor;

    // асинхронна функція, яка керує процесом спалаху
    protected IEnumerator FadeInCoroutine()
    {
        StartCoroutine(SetVisibility(startTime));
        yield return new WaitForSeconds(betweenTime);
        StartCoroutine(SetInvisibility(endTime));
    }

    // Функція зміни прозорості UI об'єкта
    protected Color SetAlpha(float alpha)
    {
        _imageColor.a = alpha;
        return _imageColor;
    }

    // асинхронна функція, яка поступово збільшує прозорість UI об'єкта
    private IEnumerator SetVisibility(float time)
    {
        for (float alpha = 0.05f; alpha <= normalAlpha; alpha += 0.05f)
        {
            _fadedImage.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }

    // асинхронна функція, яка поступово зменшує прозорість UI об'єкта
    private IEnumerator SetInvisibility(float time)
    {
        for (float alpha = normalAlpha; alpha >= -0.01f; alpha -= 0.01f)
        {
            _fadedImage.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }
}