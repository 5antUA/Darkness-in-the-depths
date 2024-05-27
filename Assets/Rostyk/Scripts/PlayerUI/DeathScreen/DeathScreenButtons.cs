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

    public void NewGame()
    {
        FadeScreen.SetActive(true);
        AudioSource.PlayOneShot(ButtonClickClip);
        StartCoroutine(NewGameCoroutine());
    }

    public void ToMainMenu()
    {
        FadeScreen.SetActive(true);
        
        AudioSource.PlayOneShot(ButtonClickClip);
        StartCoroutine(ToMainMenuCoroutine());
    }

    private IEnumerator NewGameCoroutine()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        AudioSource.PlayOneShot(EvilLaughtClip);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("RostykScene");
    }

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
