using mobs;
using UnityEngine;
using UnityEngine.AI;

public class WattermobMonster : Monster
{
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
            SecondAudioSourse.Stop();
            mobDamager.enabled = false;
            makephicik();
            sounds.PlaySound(sounds.sounds[2], 3, p1: 0.8f, p2: 1.3f);
            Destroy(gameObject, 5);
            deathchaker = true;
        }
    }
}


