using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamaggerControl : MobDamager
{
    public float corutineTime=0.5f;
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
            StartCoroutine(PushTime(enemy));
            Debug.Log(monsterDamage);


        }
        // если не попал во врага
        else
        {
            // Debug.Log("EBLAN, YOU MISSED!");
        }
    }

    private IEnumerator PushTime(Player enemy) {
        yield return new WaitForSeconds(corutineTime);
        enemy.GetComponent<CharacterController>().
                Move(new Vector3(enemy.transform.position.x, enemy.transform.position.y + 3, enemy.transform.position.z - 5) * Time.deltaTime * 7);
    }
}
