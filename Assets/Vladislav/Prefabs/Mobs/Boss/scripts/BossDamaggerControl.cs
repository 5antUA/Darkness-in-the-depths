using System.Collections;
using UnityEngine;

public class BossDamaggerControl : MobDamager
{
    public float corutineTime = 0.5f;
    private bool attacking = false;
    private bool ispushing = false;
    private Player enemy;
    private Sounds sounds;
    private void Start()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<Monster>();
        monsterDamage = monster.Damage;
        sounds = GetComponent<Sounds>();
    }

    private void Update()
    {
        if (animator.GetBool("Attack"))
        {
            Hitting();
        }
        pushing();
    }
    private void Hitting()
    {
        enemy = GetEnemy();
        // если попал во врага
        if (enemy != null && !attacking)
        {
            enemy.TakeDamage(monsterDamage);
            attacking = true;
            StartCoroutine(PushTime());
        }

    }                                                                               
    private void pushing()
    {
        if (enemy != null && ispushing)
        {
            enemy.GetComponent<CharacterController>().Move(new Vector3(enemy.transform.position.x,
          enemy.transform.position.y + 5, enemy.transform.position.z - 10) * Time.deltaTime);
        }
    }
    private IEnumerator PushTime()
    {
        yield return new WaitForSeconds(corutineTime);
        sounds.PlaySound(sounds.sounds[4], 100, true);
        EventManager.ShowDamageScreen();
        ispushing = true;
        attacking = false;
        yield return new WaitForSeconds(1);
        ispushing = false;
    }
}
