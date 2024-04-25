using System.Collections;
using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private const string key = "PlayerKEY";
    private IStorageService storage = new SaveToFile();
    SavedData.Player NewData;

    private void Start()
    {
        var cor = LoadGame();
        StartCoroutine(cor);

        Debug.Log($"{transform.position}");
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(1.5f);

        Debug.Log("3 sec.....");
        storage.Load<SavedData.Player>(key, data =>
        {
            gameObject.transform.position = data._player;
            Debug.Log($"Load data {data._player}");
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            var newData = new SavedData.Player() { _player = transform.position };
            storage.Save(key, newData);

            Debug.Log("Save data");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            storage.Load<SavedData.Player>(key, data =>
            {
                gameObject.transform.position = data._player;
                Debug.Log($"Load data {data._player}");
            });
        }
    }
}
