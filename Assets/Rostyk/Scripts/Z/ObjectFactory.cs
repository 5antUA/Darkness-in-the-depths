using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    private SavedData.ObjectFactoryData ObjectFactoryData;

    public List<GameObject> PrefabObjects = new List<GameObject>();
    private List<GameObject> CloneObjects = new List<GameObject>();


    private void Start()
    {
        ObjectFactoryData = new SavedData.ObjectFactoryData();
        ObjectFactoryData = ObjectFactoryData.Load(PrefabObjects);

        LoadGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame(true);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            SaveGame();
        }
    }


    private void DestroyCloneObjects()
    {
        foreach (var obj in CloneObjects)
        {
            Destroy(obj);
        }
    }

    private void LoadGame(bool gameReload = false)
    {
        if (gameReload)
        {
            DestroyCloneObjects();
            CloneObjects = new List<GameObject>();
        }

        for (int i = 0; i < PrefabObjects.Count; i++)
        {
            if (PrefabObjects[i] == null)
                continue;

            var pos = ObjectFactoryData.EnemiesList[i].position;
            var rot = ObjectFactoryData.EnemiesList[i].rotation;

            CloneObjects.Add(Instantiate(PrefabObjects[i], pos, rot));
        }
    }

    private void SaveGame()
    {
        for (int i = 0; i < PrefabObjects.Count; i++)
        {
            Vector3 pos = CloneObjects[i].transform.position;
            Quaternion rot = CloneObjects[i].transform.rotation;

            ObjectFactoryData.EnemiesList[i] = new SavedData.EnemyData(pos, rot);
        }
    }
}
