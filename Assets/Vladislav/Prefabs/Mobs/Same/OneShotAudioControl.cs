using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAudioControl : StateMachineBehaviour
{
    public int ClipNumber;
    public int ClipVolume = 1;
    protected Sounds sounds;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sounds = animator.GetComponent<Sounds>();
        if (!sounds.isplaying) sounds.PlaySound(sounds.sounds[ClipNumber], ClipVolume, p1: 1, p2: 1);
    }
}
