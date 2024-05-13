using mobs;
using UnityEngine;


// Empty class
public class Monster : Character
{

    public Animator animation;
    public Rigidbody[] ALLrigidbodys;

    private void Awake()
    {
        for (int i = 0; i < ALLrigidbodys.Length; i++)
        {
            ALLrigidbodys[i].isKinematic = true;
        }
    }
    private void Start()
    {
        Debug.Log("Monster has been spawnted");
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
        if (IsDead)
        {
            makephicik();
            Destroy(gameObject, 5);
        }
    }
    public void makephicik()
    {
        animation.enabled = false;
        for (int i = 0; i < ALLrigidbodys.Length; i++)
        {
            ALLrigidbodys[i].isKinematic = false;
        }
    }
}

