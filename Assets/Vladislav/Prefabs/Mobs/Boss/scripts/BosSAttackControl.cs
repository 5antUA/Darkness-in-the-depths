using UnityEngine;

namespace mobs
{
    public class BosSAttackControl : AttackControl
    {

        private void Update()
        {
            Attack();
        }
        private void Attack()
        {
            distance = Vector3.Distance(mob.transform.position, player.transform.position);
            if (distance < attackDistanse && SpawnSimpleMob.MonsterCounter <= 3)
            {
                StartCoroutine(routine: AttackControll());
                mob.transform.LookAt(new Vector3(player.transform.position.x, mob.transform.position.y, player.transform.position.z));
                Debug.Log("weeee");
            }
        }

       
    }
}