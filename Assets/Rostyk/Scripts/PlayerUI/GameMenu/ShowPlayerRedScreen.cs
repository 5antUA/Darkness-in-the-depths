using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerRedScreen : MonoBehaviour
{
    private Image ImageRedScreen;
    private Color ImageColor;
    private float endAlpha = 0.5f;

    private void Start()
    {
        ImageRedScreen = this.GetComponent<Image>();
        EventManager.ShowPlayerRedScreenEvent += ShowThis;

        ImageColor = ImageRedScreen.color;
        ImageRedScreen.color = SetAlpha(0f);
    }


    private IEnumerator CoroutineScreen()
    {
        StartCoroutine(SetVisibility(0.02f));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SetInvisibility(0.05f));
    }

    private void ShowThis()
    {
        StartCoroutine(CoroutineScreen());
        EventManager.ShowPlayerRedScreenEvent -= ShowThis;
    }


    #region Методы смены альфа-канала Image
    private Color SetAlpha(float alpha)
    {
        ImageColor.a = alpha;
        return ImageColor;
    }

    private IEnumerator SetVisibility(float time)
    {
        for (float alpha = 0.05f; alpha <= endAlpha; alpha += 0.05f)
        {
            ImageRedScreen.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator SetInvisibility(float time)
    {
        for (float alpha = endAlpha; alpha >= -0.05f; alpha -= 0.05f)
        {
            ImageRedScreen.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }
    #endregion
}
