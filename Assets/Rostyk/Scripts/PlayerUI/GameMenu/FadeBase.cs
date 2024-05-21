using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public abstract class FadeBase : MonoBehaviour
{
    protected Image FadedImage;
    protected Color ImageColor;

    public float normalAlpha = 1f;
    [Space]
    public float startTime;
    public float betweenTime;
    public float endTime;


    protected IEnumerator FadeInCoroutine()
    {
        StartCoroutine(SetVisibility(startTime));
        yield return new WaitForSeconds(betweenTime);
        StartCoroutine(SetInvisibility(endTime));
    }


    #region Alpha settings
    protected Color SetAlpha(float alpha)
    {
        ImageColor.a = alpha;
        return ImageColor;
    }

    private IEnumerator SetVisibility(float time)
    {
        for (float alpha = 0.05f; alpha <= normalAlpha; alpha += 0.05f)
        {
            FadedImage.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator SetInvisibility(float time)
    {
        for (float alpha = normalAlpha; alpha >= -0.01f; alpha -= 0.01f)
        {
            FadedImage.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }
    #endregion
}