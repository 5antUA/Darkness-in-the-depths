using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void ContinueButton()
    {
        SceneManager.LoadScene("RostykScene");
    }
}
