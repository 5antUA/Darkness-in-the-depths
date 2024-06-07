using System.Collections;
using UnityEngine;

public class MobDamager : MonoBehaviour
{
    protected Player enemy;
    protected Animator animator;
    protected Monster monster;        //щоб брати інфу про урон
    protected float monsterDamage;    // урон, расчитаный по формуле (ориг.Damage в Properties)
    [HideInInspector] public bool isdamage = false;
    public float takeDamageCorutine = 0.02f;
    [SerializeField] protected Transform _startShooter;



    private void Start()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<Monster>();
        monsterDamage = monster.Damage;
    }

    private void Update()
    {
        Hitting();
    }

    private void Hitting()
    {
        if (animator.GetBool("Attack") == true && !isdamage)
        {
            enemy = GetEnemy();
            if (enemy == null) return;
            else if (enemy.CompareTag("Player"))
            {
                isdamage = true;
                StartCoroutine(TakeDamage());
            }
        }
    }

    private IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(takeDamageCorutine);
        enemy = GetEnemy();
        if (enemy != null)
        {
            EventManager.ShowDamageScreen();
            enemy.TakeDamage(monsterDamage);
        }
        isdamage = false;
    }

    protected Player GetEnemy()
    {
        RaycastHit hit = GetComponentInChildren<ThrowRay>().GetHit(5);

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