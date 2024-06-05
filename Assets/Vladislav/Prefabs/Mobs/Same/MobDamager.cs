using System.Collections;
using UnityEngine;

public class MobDamager : MonoBehaviour
{
    protected Player enemy;
    protected Animator animator;
    protected Monster monster;        //��� ����� ���� ��� ����
    protected float monsterDamage;    // ����, ���������� �� ������� (����.Damage � Properties)
    private bool isdamage = false;
    public float takeDamageCorutine = 0.02f;



    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
        monster = GetComponent<Monster>();
        monsterDamage = monster.Damage;
    }

    private void Update()
    {
        if (animator.GetBool("Attack") == true && !isdamage)
        {
            StartCoroutine(TakeDamage());
            isdamage = true;

        }
    }

    private IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(takeDamageCorutine);
        enemy.TakeDamage(monsterDamage);
        isdamage = false;
    }
}
