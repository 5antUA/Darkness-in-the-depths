using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreenButtons : MonoBehaviour
{
    [SerializeField] private GameObject FadeScreen;
    [SerializeField] private AudioClip GameoverClip;
    [SerializeField] private AudioClip EvilLaughtClip;
    [SerializeField] private AudioClip ButtonClickClip;
    [SerializeField] private AudioSource AudioSource;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // кнопка нової гри
    public void NewGame()
    {
        FadeScreen.SetActive(true);
        AudioSource.PlayOneShot(ButtonClickClip);
        StartCoroutine(NewGameCoroutine());
    }

    // кнопка повернення на головне меню
    public void ToMainMenu()
    {
        FadeScreen.SetActive(true);
        
        AudioSource.PlayOneShot(ButtonClickClip);
        StartCoroutine(ToMainMenuCoroutine());
    }

    // асинхронна функція запуску сцени загрузки
    private IEnumerator NewGameCoroutine()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        AudioSource.PlayOneShot(EvilLaughtClip);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("LoadScene");
    }

    // асинхронна функція запуску головного меню
    private IEnumerator ToMainMenuCoroutine()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yield return new WaitForSeconds(1f);
        AudioSource.PlayOneShot(GameoverClip);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Main menu");
    }
}
