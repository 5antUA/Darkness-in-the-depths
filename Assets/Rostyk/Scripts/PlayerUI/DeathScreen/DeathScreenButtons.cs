using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButtons : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("RostykScene");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void LoadPidarasScene()
    {
        SceneManager.LoadScene("gym");
    }
}
