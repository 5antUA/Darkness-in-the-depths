using UnityEngine;


// клас, який реалізує програвання звуку при натисканні кнопки
public class PoinerClickStart : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;      // AudioSource для програвання звуку
    [SerializeField] private AudioClip _AudioClip;          // AudioClip звуку


    // функція для програвання звуку
    public void AudioPlay()
    {
        _AudioSource.PlayOneShot(_AudioClip);
    }
}
