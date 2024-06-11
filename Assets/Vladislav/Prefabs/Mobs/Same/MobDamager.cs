using System.Collections;
using UnityEngine;

public class MobDamager : MonoBehaviour
{
    public float takeDamageCorutine = 0.02f;

    [SerializeField] protected Transform _startShooter;
    protected Player enemy;
    protected Animator animator;
    protected Monster monster;        //щоб брати інформацію про урон

    [HideInInspector] public bool isdamage = false;
    protected float monsterDamage; 

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