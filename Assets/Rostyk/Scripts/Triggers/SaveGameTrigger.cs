using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SaveGameTrigger : MonoBehaviour
{
    private SavedData.PlayerPositionData PlayerPosData;


    private void Start()
    {
        PlayerPosData = new SavedData.PlayerPositionData();

        PlayerPosData = PlayerPosData.Load();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
}
