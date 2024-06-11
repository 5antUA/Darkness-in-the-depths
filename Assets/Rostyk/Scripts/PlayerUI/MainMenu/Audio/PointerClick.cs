using UnityEngine;
using UnityEngine.UI;


// клас, який реалізує програвання звуку при натисканні кнопки
public class PointerClick : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;      // AudioSource для програвання звуку
    [SerializeField] private AudioClip _AudioClip;          // AudioClip звуку
    [SerializeField] private Button Button;                 // кнопка, яка перевіряється на активність


    // функція для програвання звуку
    public void AudioPlay()
    {
        if (Button.interactable)
            _AudioSource.PlayOneShot(_AudioClip);
    }
}
