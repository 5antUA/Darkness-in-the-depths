using UnityEngine.UI;


public class ShowDamageScreen : FadeBase
{
    private void Start()
    {
        _fadedImage = this.GetComponent<Image>();
        EventManager.ShowDamageScreenEvent += RunFadeEffect; // ���������� �� �����
        _imageColor = _fadedImage.color;
        _fadedImage.color = SetAlpha(0f);
    }

    // �������, ��� ������� ������ �������
    private void RunFadeEffect()
    {
        StartCoroutine(FadeInCoroutine());
    }

    // �� ���� ����� ��'���� ���������� �� ������
    private void OnDisable()
    {
        EventManager.ShowDamageScreenEvent -= RunFadeEffect;
    }
}
