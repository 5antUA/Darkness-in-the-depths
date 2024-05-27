using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShowDeathScreen : MonoBehaviour
{
    public float showTime;

    [SerializeField] private Image BlackImage;
    [SerializeField] private Image BackgroundImage;
    [SerializeField] private Image YouDeadImage;

    private Color BlackImageColor;
    private Color BackgroundImageColor;
    private Color YouDeadImageColor;


    private void Start()
    {
        BlackImageColor = BlackImage.color;
        BackgroundImageColor = BackgroundImage.color;
        YouDeadImageColor = YouDeadImage.color;

        EventManager.OnPlayerDeathEvent += RunShowEffect;
    }

    private void RunShowEffect()
    {
        EventManager.OnPlayerDeathEvent -= RunShowEffect;
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        for (float alpha = 0.02f; alpha <= 1f; alpha += 0.02f)
        {
            BlackImage.color = SetAlpha(BlackImageColor, alpha);
            BackgroundImage.color = SetAlpha(BackgroundImageColor, alpha);
            YouDeadImage.color = SetAlpha(YouDeadImageColor, alpha);
            yield return new WaitForSeconds(showTime);
        }

        SceneManager.LoadScene("DeathScreen");
    }

    protected Color SetAlpha(Color imageColor, float alpha)
    {
        imageColor.a = alpha;
        return imageColor;
    }
}