using mobs;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBoss : Monster
{
    private GameObject SpawnSinplemob;
    private void Update()
    {
        if (SpawnSinplemob == null)
            SpawnSinplemob = GameObject.FindWithTag("SpawnSimpleMob");      //��� �������� ������
        OnMonsterDeath();
    }
    private void OnMonsterDeath()
    {
        if (IsDead && !deathchaker)
        {
            SecondAudioSourse.Stop();
            sounds.PlaySound(sounds.sounds[0],3);
            makephicik();
            Destroy(SpawnSinplemob);
            deathchaker = true;
        }
    }
}

