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


    private void Start()
    {
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
        storage.Load<Vector3>(key, data =>
        {
            currentPlayer = Instantiate(player, data, Quaternion.identity);
        });
    }
}
