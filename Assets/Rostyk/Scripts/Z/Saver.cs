using UnityEngine;

public class Saver : MonoBehaviour
{
    private const string key = "PlayerKEY";

    void Awake()
    {
        var newData = SaveManager.Load<Vector3>(key);
        this.gameObject.transform.position = newData;
        Debug.Log("Awake");
    }

    void Update()
    {
        var newData = this.gameObject.transform.position;
        SaveManager.Save(key, newData);

        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveManager.Delete(key);
            Debug.Log("Delete data");
        }
    }
}
