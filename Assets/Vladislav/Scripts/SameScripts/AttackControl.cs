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
        protected Animator animator;
        protected bool isattacking = false;
        protected float distance;
        public virtual void Awake()
        {
            mob = gameObject;
            animator = GetComponent<Animator>();
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {

            if (player == null) player = GameObject.FindWithTag("Player");
            Attack();
        }

        public virtual IEnumerator AttackControll()
        {
            yield return new WaitForSeconds(CorutineTime);
            while (distance < attackDistanse)
            {
                animator.SetBool("Attack", true);
                yield return new WaitForSeconds(CorutineTime);
            }
            animator.SetBool("Attack", false);
            isattacking = false;
        }

        private void Attack()
        {
            distance = Vector3.Distance(mob.transform.position, player.transform.position);
            if (distance < attackDistanse)
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