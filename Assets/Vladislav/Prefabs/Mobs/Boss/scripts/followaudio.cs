using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followaudio : MonoBehaviour
{
    private Animator animator;
    private Sounds sounds;
    void Start()
    {
        animator = GetComponent<Animator>();
        sounds = GetComponent<Sounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Following") && !animator.GetBool("Attack") && !sounds.isplaying ) {

            sounds.PlaySound(sounds.sounds[2],p1:1,p2:5, volume:5);

        } 
    }
}
