using UnityEngine;

public class MobDamager : MonoBehaviour
{
    protected Animator animator;
    protected Monster monster;        //щоб брати інфу про урон

    protected float monsterDamage;                                 // урон, расчитаный по формуле (ориг.Damage в Properties)
    [SerializeField] protected Transform _startShooter;            // точка рейкасту

    private void Start()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<Monster>();
        monsterDamage = monster.Damage;
    }

    private void Update()
    {
        if (animator.GetBool("Attack") == true)
        {
            Hitting();
        }
    }

    private void Hitting()
    {
        Player enemy = GetEnemy();
         
        // если попал во врага
        if (enemy != null)
        {
            enemy.TakeDamage(monsterDamage);
        }
    }

    // Поиск врага лучем
    protected Player GetEnemy()
    {
        RaycastHit hit = GetComponentInChildren<ThrowRay>().GetHit(4);

        if (hit.collider != null)
        {
            return hit.collider.GetComponent<Player>();
        }
        else
        {
            return null;
        }
    }
}
