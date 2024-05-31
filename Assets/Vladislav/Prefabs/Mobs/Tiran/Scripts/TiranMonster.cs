using mobs;
using UnityEngine;
using UnityEngine.AI;

public class TiranMonster:Monster
{
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
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(gameObject.GetComponent<AttackControl>());
            sounds.PlaySound(sounds.sounds[2], 3, p1: 0.8f, p2: 1.3f);
            Destroy(gameObject,1);
            deathchaker = true;
        }
    }
}


