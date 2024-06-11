using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShowDeathScreen : MonoBehaviour
{
    [SerializeField] private Image BlackImage;
    [SerializeField] private Image BackgroundImage;
    [SerializeField] private Image YouDeadImage;

    public AudioClip DeathSound;
    public float showTime;

    private Color _blackImageColor;
    private Color _backgroundImageColor;
    private Color _youDeadImageColor;
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();  
        _blackImageColor = BlackImage.color;
        _backgroundImageColor = BackgroundImage.color;
        _youDeadImageColor = YouDeadImage.color;
        EventManager.OnPlayerDeathEvent += RunShowEffect; // підписуємося на івент
    }

    // на кінці життя об'єкта відписуємося від івента
    private void OnDisable()
    {
        EventManager.OnPlayerDeathEvent -= RunShowEffect;
    }

    // функція, яка запускає процес спалаху
    private void RunShowEffect()
    {
        EventManager.OnPlayerDeathEvent -= RunShowEffect;
        SoundOfDeath();
        StartCoroutine(FadeInCoroutine());
    }

    // програємо звук смерті
    private void SoundOfDeath()
    {
        _audioSource.PlayOneShot(DeathSound);
    }

    // асинхронна функція, яка керує процесом спалаху
    private IEnumerator FadeInCoroutine()
    {
        for (float alpha = 0.02f; alpha <= 1f; alpha += 0.02f)
        {
            BlackImage.color = SetAlpha(_blackImageColor, alpha);
            BackgroundImage.color = SetAlpha(_backgroundImageColor, alpha);
            YouDeadImage.color = SetAlpha(_youDeadImageColor, alpha);
            yield return new WaitForSeconds(showTime);
        }

        SceneManager.LoadScene("DeathScreen");
    }

    // Функція зміни прозорості UI об'єкта
    protected Color SetAlpha(Color imageColor, float alpha)
    {
        imageColor.a = alpha;
        return imageColor;
    }
}