using mobs;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBoss : Monster
{
    private GameObject SpawnSinplemob;  //поле трігеру спавну простих монстрів

    private void Update()
    {
        if (SpawnSinplemob == null)
            SpawnSinplemob = GameObject.FindWithTag("SpawnSimpleMob");      //для знищення трігеру
        OnMonsterDeath();
    }

    //змінений менеджер зниження для боса
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