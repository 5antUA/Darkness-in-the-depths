using UnityEngine;

public class MobDamager : MonoBehaviour
{
    protected Animator animator;
    protected Monster monster;        //��� ����� ���� ��� ����

    protected float monsterDamage;                                 // ����, ���������� �� ������� (����.Damage � Charactersd)

    [SerializeField] protected Transform _startShooter;            // ����� ��������
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
         
        // ���� ����� �� �����
        if (enemy != null)
        {
            enemy.TakeDamage(monsterDamage);
            Debug.Log(monsterDamage);


        }
        // ���� �� ����� �� �����
        else
        {
            // Debug.Log("EBLAN, YOU MISSED!");
        }
    }

    // ����� ����� �����
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
