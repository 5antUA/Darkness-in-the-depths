using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerClick : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip _AudioClip;

    public void AudioPlay()
    {
        _AudioSource.PlayOneShot(_AudioClip);
    }
}
