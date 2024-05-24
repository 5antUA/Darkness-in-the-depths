using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    private SavedData.ObjectFactoryData ObjectFactoryData;

    public List<GameObject> InstatiateObjects = new List<GameObject>();


    private void Start()
    {
        ObjectFactoryData = new SavedData.ObjectFactoryData();
        ObjectFactoryData = ObjectFactoryData.Load(InstatiateObjects);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    private void LoadGame()
    {
        for (int i = 0; i < InstatiateObjects.Count; i++)
        {
            if (InstatiateObjects[i] == null)
                continue;

            var pos = ObjectFactoryData.EnemiesList[i].position;
            var rot = ObjectFactoryData.EnemiesList[i].rotation;

            Instantiate(InstatiateObjects[i], pos, rot);
        }
    }

    //private void SavePlayerPosition()
    //{
    //    for (int i = 0; i < InstatiateObjects.Count; i++)
    //    {


    //        var pos = ObjectFactoryData.EnemiesList[i].position;
    //        var rot = ObjectFactoryData.EnemiesList[i].rotation;

    //        Instantiate(InstatiateObjects[i], pos, rot);
    //    }
    //}
}
