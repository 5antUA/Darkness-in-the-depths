using UnityEngine;

namespace mobs
{
    public class BosSAttackControl : BlockAttackControl
    {
        private void Update()
        {
            Attack();
        }
        //логіка атаки боса
        private void Attack()
        {
            distance = Vector3.Distance(this.transform.position, player.transform.position);
            if (distance < attackDistanse && SpawnSimpleMob.MonsterCounter <= 3)//доданий лічильник малих мобів
            {
                if (!isattacking)
                {
                    isattacking = true;
                    StartCoroutine(routine: AttackControll());
                }
                this.transform.LookAt(new Vector3(player.transform.position.x, 
                    this.transform.position.y, player.transform.position.z));
            }
        }   
    }
}