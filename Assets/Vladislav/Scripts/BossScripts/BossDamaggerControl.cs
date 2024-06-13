using System.Collections;
using UnityEngine;

public class BossDamaggerControl : MobDamager
{
    public float corutineTime = 0.5f;        //час для нанесення урону разом з анімацією

    private Sounds sounds;                   //для відтворення звуків
    //прапосці для уникання зациклювань
    private bool attacking = false;           
    private bool ispushing = false;

    //ініціалізація об'єктів
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

    //логіка нанесення урону
    private void Hitting()
    {
        enemy = GetEnemy();
        if (enemy != null && !attacking)
        {
            attacking = true;
            StartCoroutine(PushTime());
            enemy.TakeDamage(monsterDamage);
        }
    }

    //метод для підкидання гравця
    private void pushing()
    {
        if (enemy != null && ispushing)
        {
            enemy.GetComponent<CharacterController>().Move(new Vector3(enemy.transform.position.x,
          enemy.transform.position.y + 10, enemy.transform.position.z - 25) * Time.deltaTime);
        }
    }

    //менеджер атаки
    private IEnumerator PushTime()
    {
        yield return new WaitForSeconds(corutineTime);
        sounds.PlaySound(sounds.sounds[4], 100, true);
        EventManager.ShowDamageScreen();
        ispushing = true;
        attacking = false;
        yield return new WaitForSeconds(2);
        ispushing = false;
    }
}