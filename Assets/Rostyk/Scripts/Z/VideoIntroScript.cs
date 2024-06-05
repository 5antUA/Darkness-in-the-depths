using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VideoIntroScript : MonoBehaviour
{
    public int WaitTime;
    

    void Awake()
    {
        StartCoroutine(WaitForLevel());
    }

    private IEnumerator WaitForLevel()
    {
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene("Main Menu");
    }
}
