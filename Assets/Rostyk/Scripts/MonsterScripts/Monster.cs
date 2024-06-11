﻿using mobs;
using UnityEngine;
using UnityEngine.AI;

public class Monster : Character
{
    public Rigidbody[] ALLrigidbodys;
    public AudioSource SecondAudioSourse;
    protected Animator animator;
    protected Sounds sounds;
    protected BlockAttackControl blockAttackControl;
    protected MobDamager mobDamager;

    protected bool deathchaker = false;

    protected void Awake()
    {
        animator = GetComponent<Animator> ();
        mobDamager = GetComponent<MobDamager>();
        blockAttackControl = GetComponent<BlockAttackControl>();
        sounds = GetComponent<Sounds>();
        for (int i = 0; i < ALLrigidbodys.Length; i++)
        {
            ALLrigidbodys[i].isKinematic = true;
        }
    }

    private void Update()
    {
        OnMonsterDeath();
    }

    private void OnMonsterDeath()
    {
        if (IsDead && !deathchaker)
        {
            SecondAudioSourse.Stop();
            mobDamager.enabled = false;
            makephicik();
            sounds.PlaySound(sounds.sounds[2], 3,p1:0.8f,p2:1.3f);
            Destroy(gameObject, 60);
            deathchaker = true;
            blockAttackControl.PlayerModificationStop();
        }
    }

    protected void makephicik()
    {
        animator.enabled = false;
        for (int i = 0; i < ALLrigidbodys.Length; i++)
        {
            ALLrigidbodys[i].isKinematic = false;
            ALLrigidbodys[i].mass = 1;
        }
        Destroy(GetComponent<BlockAttackControl>());
        Destroy(GetComponent<NavMeshAgent>());
    }
}