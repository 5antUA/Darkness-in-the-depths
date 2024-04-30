using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretButton : MonoBehaviour
{
    [SerializeField] private Secret secret;
    [SerializeField] private GameObject SecretUI;

    public void Secret()
    {
        if (secret.TouchCount >= 10)
        {
            SecretUI.SetActive(true);
        }
    }
}
