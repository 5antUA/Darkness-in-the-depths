using mobs;
using UnityEngine;
using UnityEngine.AI;


// Empty class
public class Monster : Character
{
    public Rigidbody[] ALLrigidbodys;
    public AudioSource SecondAudioSourse;
    protected Animator animator;
    protected Sounds sounds;
    protected MobDamager mobDamager;
    protected bool deathchaker = false;


    protected void Awake()
    {
        animator = GetComponent<Animator> ();
        mobDamager = GetComponent<MobDamager>();
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
            Destroy(gameObject, 5);
            deathchaker = true;
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
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(GetComponent<AttackControl>());

    }
}


