using mobs;
using Unity.VisualScripting;
using UnityEngine;

// Empty class
public class MonsterBoss : Monster
{
    private GameObject SpawnSinplemob;
    private void Update()
    {
        if (SpawnSinplemob == null)
            SpawnSinplemob = GameObject.FindWithTag("S");
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
            Destroy(SpawnSinplemob);
            
        }
    }
}

