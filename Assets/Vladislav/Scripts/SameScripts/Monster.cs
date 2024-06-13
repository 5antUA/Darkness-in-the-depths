using mobs;
using UnityEngine;
using UnityEngine.AI;

public class Monster : Character
{
    //данні для взаємодії
    public Rigidbody[] ALLrigidbodys;
    public AudioSource SecondAudioSourse;
    protected Animator animator;
    protected Sounds sounds;
    protected BlockAttackControl blockAttackControl;
    protected MobDamager mobDamager;

    protected bool deathchaker = false; //флажок смерті монстра (для уникання зациклювання)

    //ініціалізація
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

    //менеджер смерті монста
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

    //функція яка заставляє монстра падати у мипадку смерті
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