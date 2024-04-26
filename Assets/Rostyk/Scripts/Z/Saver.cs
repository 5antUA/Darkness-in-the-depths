using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private const string key = "PlayerKEY";
    private SaveToFile storage = new SaveToFile();

    private GameObject currentPlayer;
    [SerializeField] private GameObject player;

    [Serializable]
    private class MyVector3
    {
        public float x;
        public float y;
        public float z;

        public MyVector3(int x = 0, int y = 0, int z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    private void Start()
    {
        try { LoadGame(); }
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
        MyVector3 newData;
        if (defaultParameters)
        {
            newData = new MyVector3(-42, 1, 125);
        }
        else
        {
            newData = new MyVector3()
            {
                x = currentPlayer.transform.position.x,
                y = currentPlayer.transform.position.y,
                z = currentPlayer.transform.position.z
            };
        }

        storage.Save(key, newData);
    }

    private void LoadGame()
    {
        storage.Load<MyVector3>(key, data =>
        {
            Vector3 tempVec = new Vector3(data.x, data.y, data.z);
            currentPlayer = Instantiate(player, tempVec, Quaternion.identity);
        });
    }
}
