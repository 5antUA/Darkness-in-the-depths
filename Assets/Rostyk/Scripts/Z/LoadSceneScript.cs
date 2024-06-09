using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadSceneScript : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private Image Skull;

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