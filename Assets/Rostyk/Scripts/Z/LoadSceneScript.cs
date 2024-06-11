using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// клас, який реалізую екран загрузки
public class LoadSceneScript : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;      // весь об'єкт екрану загрузки
    [SerializeField] private Image Skull;                   // картинка загрузки


    // асинхронний метод старт, який асинхронно завантажує ігрову сцену
    public IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        LoadingScreen.SetActive(true);
        AsyncOperation LoadAsync = SceneManager.LoadSceneAsync("FinalGayplay");
        while (!LoadAsync.isDone)
        {
            Skull.fillAmount = LoadAsync.progress;
            yield return null;
        }
    }
}
