using System.Collections;
using System.IO;
using UnityEngine;


// ¬≈ÿ¿“‹ — –»œ“ Õ¿ Œ¡⁄≈ “ EntryPoint
public class LoadManager : MonoBehaviour
{
    private const string key = "PlayerKEY";
    private SavingToFile storage = new SavingToFile();

    private GameObject currentPlayer;
    [SerializeField] private GameObject player;
    private Vector3 defaultPlayerPosition = new Vector3(-42, 1, 125);

    [SerializeField] private GameObject LoadingScreen;


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        try
        {
            LoadGame();
        }
        catch (FileNotFoundException)
        {
            Debug.Log("Force save game");
            SaveGame(true);
            LoadGame();
        }

        LoadingScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveGame();
        }
    }

    private void SaveGame(bool defaultParameters = false)
    {
        Vector3 playerPos = defaultParameters ?
            defaultPlayerPosition :
            currentPlayer.transform.position;

        storage.Save(key, playerPos);
    }

    private void LoadGame()
    {
        Vector3 data = new Vector3();
        storage.Load<Vector3>(key, newData => data = newData);
        currentPlayer = Instantiate(player, data, Quaternion.identity);
    }
}
