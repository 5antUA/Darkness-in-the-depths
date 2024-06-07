using mobs;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBoss : Monster
{
    private GameObject SpawnSinplemob;
    private void Update()
    {
        if (SpawnSinplemob == null)
            SpawnSinplemob = GameObject.FindWithTag("SpawnSimpleMob");      //для знищення трігеру
        OnMonsterDeath();
    }
    private void OnMonsterDeath()
    {
        if (IsDead && !deathchaker)
        {
            SecondAudioSourse.Stop();
            mobDamager.enabled = false;
            Destroy(GetComponent<BosSAttackControl>());
            sounds.PlaySound(sounds.sounds[0],3);
            makephicik();
            Destroy(SpawnSinplemob);
            deathchaker = true;
        }
    }
}

