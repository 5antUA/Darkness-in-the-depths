using UnityEngine;


public class PoinerClickStart : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip _AudioClip;

    public void AudioPlay()
    {
        _AudioSource.PlayOneShot(_AudioClip);
    }
}
