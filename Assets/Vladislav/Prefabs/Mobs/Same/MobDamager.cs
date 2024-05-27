using UnityEngine;

public class MobDamager : MonoBehaviour
{
    protected Animator animator;
    protected Monster monster;        //��� ����� ���� ��� ����

    protected float monsterDamage;                                 // ����, ���������� �� ������� (����.Damage � Properties)
    [SerializeField] protected Transform _startShooter;            // ����� ��������

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
         
        // ���� ����� �� �����
        if (enemy != null)
        {
            enemy.TakeDamage(monsterDamage);
        }
    }

    // ����� ����� �����
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
