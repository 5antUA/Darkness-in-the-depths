using UnityEngine;

public class MobDamager : MonoBehaviour
{
    protected Animator animator;
    protected Monster monster;        //щоб брати інфу про урон

    protected float monsterDamage;                                 // урон, расчитаный по формуле (ориг.Damage в Charactersd)

    [SerializeField] protected Transform _startShooter;            // точка рейкасту
    // Start is called before the first frame update
    protected void Start()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<Monster>();
        monsterDamage = monster.Damage;
    }

    // Update is called once per frame
    private void Update()
    {
        if (animator.GetBool("Attack") == true)
        {
            Hitting();
            Debug.Log(monsterDamage);

        }
    }

    private void Hitting()
    {
        Player enemy = GetEnemy();
         
        // если попал во врага
        if (enemy != null)
        {
            enemy.TakeDamage(monsterDamage);
            Debug.Log(monsterDamage);


        }
        // если не попал во врага
        else
        {
            // Debug.Log("EBLAN, YOU MISSED!");
        }
    }

    // Поиск врага лучем
    protected Player GetEnemy()
    {
        RaycastHit hit = GetComponentInChildren<ThrowRay>().GetHit(3);


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
