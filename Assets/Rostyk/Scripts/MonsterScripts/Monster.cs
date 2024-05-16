using mobs;
using UnityEngine;
using UnityEngine.AI;


// Empty class
public class Monster : Character
{
    public Animator animation;
    public Rigidbody[] ALLrigidbodys;
    protected bool deathchaker = false;

    protected void Awake()
    {
        for (int i = 0; i < ALLrigidbodys.Length; i++)
        {
            ALLrigidbodys[i].isKinematic = true;
        }
    }

    private void Update()
    {
        OnMonsterDeath();
    }

    private void OnDestroy()
    {
        SpawnSimpleMob.MonsterCounter--;
    }
    private void OnMonsterDeath()
    {
        if (IsDead && !deathchaker)
        {
            makephicik();
            Destroy(gameObject, 5);
            deathchaker = true;
        }
    }
    protected void makephicik()
    {
        animation.enabled = false;
        for (int i = 0; i < ALLrigidbodys.Length; i++)
        {
            ALLrigidbodys[i].isKinematic = false;
            ALLrigidbodys[i].mass = 1;
        }
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(gameObject.GetComponent<AttackControl>());

    }
}


