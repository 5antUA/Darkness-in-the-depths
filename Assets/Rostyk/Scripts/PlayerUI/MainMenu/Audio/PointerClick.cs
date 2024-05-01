using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerClick : MonoBehaviour
{
    [SerializeField] private AudioSource myFX;
    [SerializeField] private AudioClip myClip;

    public void OnPointerClick()
    {
        myFX.PlayOneShot(myClip);
    }
}
