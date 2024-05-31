using UnityEngine;

namespace mobs
{
    public class BosSAttackControl : AttackControl
    {
        private void Update()
        {
            if (player == null) player = GameObject.FindWithTag("Player");
            Attack();
        }
        private void Attack()
        {

            distance = Vector3.Distance(mob.transform.position, player.transform.position);
            if (distance < attackDistanse && SpawnSimpleMob.MonsterCounter <= 3)
            {
                if (!isattacking)
                {
                    isattacking = true;
                    StartCoroutine(routine: AttackControll());
                }
                mob.transform.LookAt(new Vector3(player.transform.position.x, mob.transform.position.y, player.transform.position.z));
            }
        }   
    }
}