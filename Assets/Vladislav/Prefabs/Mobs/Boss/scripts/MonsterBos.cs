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
    private void OnDestroy()
    {
        SpawnSimpleMob.MonsterCounter--;
    }
    private void OnMonsterDeath()
    {
        if (IsDead && !deathchaker)
        {
            makephicik();
            Destroy(SpawnSinplemob);
            
        }
    }
}

