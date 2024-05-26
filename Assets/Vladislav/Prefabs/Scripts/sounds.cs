using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;

    [HideInInspector]public bool isplaying=false;
    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 1f, float p2 = 0.8f)
    {
        audioSrc.pitch = Random.Range(p1, p2);
        if (destroyed)
            AudioSource.PlayClipAtPoint(clip, transform.position);
        else
            audioSrc.PlayOneShot(clip, volume);
        
    }

    private void Update()
    {
        isplaying = audioSrc.isPlaying;
    }
}