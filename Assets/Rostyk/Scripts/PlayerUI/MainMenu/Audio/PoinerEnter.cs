using UnityEngine;


public class PoinerEnter : MonoBehaviour
{
    [SerializeField] private AudioSource myFX;
    [SerializeField] private AudioClip myClip;

    public void OnPointerEnter()
    {
        myFX.PlayOneShot(myClip);
    }
}
