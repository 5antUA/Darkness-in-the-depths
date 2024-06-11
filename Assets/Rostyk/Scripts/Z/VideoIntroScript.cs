using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// клас, який реалізує показ інтро при запускі гри
public class VideoIntroScript : MonoBehaviour
{
    public int WaitTime;
    

    void Awake()
    {
        StartCoroutine(WaitForLevel());
    }

    // асинхронна функція, яка запускає головне меню
    private IEnumerator WaitForLevel()
    {
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene("Main Menu");
    }
}
