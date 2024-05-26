using mobs;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBoss : Monster
{
    public AudioSource SecondAudioSourse;
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
            SecondAudioSourse.Stop();
            GetComponent<Sounds>().PlaySound(GetComponent<Sounds>().sounds[0],3);
            makephicik();
            Destroy(SpawnSinplemob);
            deathchaker = true;
        }
    }
}

