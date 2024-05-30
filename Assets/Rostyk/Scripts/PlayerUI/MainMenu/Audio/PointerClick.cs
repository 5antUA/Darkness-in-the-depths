using UnityEngine;
using UnityEngine.UI;

public class PointerClick : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip _AudioClip;
    [SerializeField] private Button Button;

    public void AudioPlay()
    {
        if (!Button.interactable)
            return;

        _AudioSource.PlayOneShot(_AudioClip);
    }
}
