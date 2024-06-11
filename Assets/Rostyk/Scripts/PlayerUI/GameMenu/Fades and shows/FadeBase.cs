using System.Collections;
using UnityEngine;
using UnityEngine.UI;


// ������� ����������� ����, ���� ������ ������ UI ��������
public abstract class FadeBase : MonoBehaviour
{
    public float normalAlpha = 1f;
    [Space]
    public float startTime;
    public float betweenTime;
    public float endTime;

    protected Image _fadedImage;
    protected Color _imageColor;

    // ���������� �������, ��� ���� �������� �������
    protected IEnumerator FadeInCoroutine()
    {
        StartCoroutine(SetVisibility(startTime));
        yield return new WaitForSeconds(betweenTime);
        StartCoroutine(SetInvisibility(endTime));
    }

    // ������� ���� ��������� UI ��'����
    protected Color SetAlpha(float alpha)
    {
        _imageColor.a = alpha;
        return _imageColor;
    }

    // ���������� �������, ��� ��������� ������ ��������� UI ��'����
    private IEnumerator SetVisibility(float time)
    {
        for (float alpha = 0.05f; alpha <= normalAlpha; alpha += 0.05f)
        {
            _fadedImage.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }

    // ���������� �������, ��� ��������� ������ ��������� UI ��'����
    private IEnumerator SetInvisibility(float time)
    {
        for (float alpha = normalAlpha; alpha >= -0.01f; alpha -= 0.01f)
        {
            _fadedImage.color = SetAlpha(alpha);
            yield return new WaitForSeconds(time);
        }
    }
}