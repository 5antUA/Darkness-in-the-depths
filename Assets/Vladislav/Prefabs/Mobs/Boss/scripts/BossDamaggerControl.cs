using System.Collections;
using UnityEngine;

public class BossDamaggerControl : MobDamager
{
    public float corutineTime = 0.3f;
    private bool attacking = false;
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
        if (enemy != null && attacking == false)
        {
            EventManager.ShowDamageScreen();
            attacking = true;
            enemy.TakeDamage(monsterDamage);
            StartCoroutine(PushTime(enemy));
        }
    }

    private IEnumerator PushTime(Player enemy)
    {
        yield return new WaitForSeconds(corutineTime);
        enemy.GetComponent<CharacterController>().
                Move(new Vector3(enemy.transform.localPosition.x-50 , enemy.transform.localPosition.y + 100, enemy.transform.localPosition.z-25) * Time.deltaTime);
        Debug.Log("attacking-false");
        
        attacking = false;
    }
}
