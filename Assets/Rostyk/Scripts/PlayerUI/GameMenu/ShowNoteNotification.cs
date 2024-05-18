using System.Collections;
using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ СКРИПТ НА ПОДСКАЗКУ О ЗАПИСКАХ
public class ShowNoteNotification : MonoBehaviour
{
    private Image ImageNotification;
    private Color ImageColor;

    void Start()
    {
        ImageNotification = this.GetComponent<Image>();
        EventManager.ShowNotificationEvent += ShowThis;

        ImageColor = ImageNotification.color;
        ImageNotification.color = SetAlpha(0f);
    }


    private IEnumerator CoroutineNote()
    {
        StartCoroutine(SetVisibility(0.02f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(SetInvisibility(0.05f));
    }

    private void ShowThis()
    {
        StartCoroutine(CoroutineNote());
    }


    #region Методы смены альфа-канала Image
    private Color SetAlpha(float alpha)
    {
        ImageColor.a = alpha;
        return ImageColor;
    }

    private IEnumerator SetVisibility(float time)
    {
        for (float alpha = 0.05f; alpha <= 1f; alpha += 0.05f)
        {
            ImageNotification.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator SetInvisibility(float time)
    {
        for (float alpha = 1f; alpha >= -0.05f; alpha -= 0.05f)
        {
            ImageNotification.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }
    #endregion
}