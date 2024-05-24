using System.Collections;
using UnityEngine;

namespace mobs
{
    public class AttackControl : MonoBehaviour
    {
        public float CorutineTime = 1;
        public float attackDistanse = 10;
        protected GameObject mob;
        protected GameObject player;
        protected float distance;
        protected void Awake()
        {
            mob = gameObject;
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            Attack();
        }

        protected IEnumerator AttackControll()
        {
            yield return new WaitForSeconds(CorutineTime);
            while (distance < attackDistanse)
            {
                mob.GetComponent<Animator>().SetBool("Attack", true);
                yield return new WaitForSeconds(CorutineTime);
            }
            mob.GetComponent<Animator>().SetBool("Attack", false);
        }

        private void Attack()
        {
            distance = Vector3.Distance(mob.transform.position, player.transform.position);
            if (distance < attackDistanse)
            {
                StartCoroutine(routine: AttackControll());
                mob.transform.LookAt(new Vector3(player.transform.position.x, mob.transform.position.y, player.transform.position.z));
            }
        }
    }
}