using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    [SerializeField] private GameObject _landingPlatform;

    private void Update()
    {
        Landing();
    }

    private void Landing()
    {
        gameObject.transform.Translate(Vector3.MoveTowards(gameObject.transform.position, _landingPlatform.transform.position, 3f));
    }
}
