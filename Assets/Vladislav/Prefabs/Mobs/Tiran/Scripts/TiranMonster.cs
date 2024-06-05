using mobs;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TiranMonster : Monster
{
    public int LifeTime = 180;
    private void Start()
    {
        StartCoroutine(lifeTime());
    }
    private void Update()
    {
        if (animator.GetBool("Attack") == true) StopCoroutine("lifeTime");
        OnMonsterDeath();
    }
    private void OnMonsterDeath()
    {
        if (IsDead && !deathchaker)
        {
            SecondAudioSourse.Stop();
            mobDamager.enabled = false;
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(GetComponent<AttackControl>());
            sounds.PlaySound(sounds.sounds[2], 3, p1: 0.8f, p2: 1.3f);
            Destroy(gameObject, 1);
            deathchaker = true;
        }
    }

    private IEnumerator lifeTime()
    {
        yield return new WaitForSeconds(LifeTime);
        TakeDamage(9999999f);
    }
}