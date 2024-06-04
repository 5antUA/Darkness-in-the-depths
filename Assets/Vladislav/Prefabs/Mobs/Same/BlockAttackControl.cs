using System.Collections;
using UnityEngine;

namespace mobs
{
    public class BlockAttackControl : MonoBehaviour
    {
        public float attackDistanse = 10;
        public float CorutineTime = 1;
        protected GameObject mob;
        protected GameObject player;
        protected Animator animator;
        protected Player speed;
        protected Camera camera;

        protected bool isattacking = false;
        protected float distance;
        protected float StandartWallkSpeed;
        protected float StandartSitkSpeed;
        protected float StandartSprintSpeed;
        protected float FieldOfViev;
        [Header("\t PLAYER MODIFIKATION(IF NEED)")]
        public float ModifikatePlayerSpeed=0;
        public float ModifikatePlayerFieldOfViev=0;

        public virtual void Awake()
        {
            mob = gameObject;
            animator = GetComponent<Animator>();

        }
        private void Update()
        {
            Init();
            Attack();
        }
        private void OnDestroy()
        {
            speed.WalkSpeed = StandartWallkSpeed;
            speed.CrouchSpeed = StandartSitkSpeed;
            speed.SprintSpeed = StandartSprintSpeed;
            camera.fieldOfView = FieldOfViev;
        }
        private void Init()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
                speed = player.GetComponent<Player>();
                camera = player.GetComponentInChildren<Camera>();
                StandartWallkSpeed = speed.WalkSpeed;
                StandartSitkSpeed = speed.CrouchSpeed;
                StandartSprintSpeed = speed.SprintSpeed;
                FieldOfViev = camera.fieldOfView;
                if (ModifikatePlayerSpeed == 0)
                {
                    ModifikatePlayerSpeed = speed.WalkSpeed;
                }
                if (ModifikatePlayerFieldOfViev == 0)
                {
                    ModifikatePlayerFieldOfViev = camera.fieldOfView;
                }
            }
        }
        private void Attack()
        {
            distance = Vector3.Distance(mob.transform.position, player.transform.position);
            if (distance < attackDistanse)
            {
                speed.WalkSpeed = ModifikatePlayerSpeed;
                speed.CrouchSpeed = ModifikatePlayerSpeed;
                speed.SprintSpeed = ModifikatePlayerSpeed;
                EventManager.ShowDamageScreen();
                camera.fieldOfView = ModifikatePlayerFieldOfViev;
                if (!isattacking)
                {
                    isattacking = true;
                    StartCoroutine(routine: AttackControll());
                }
                mob.transform.LookAt(new Vector3(player.transform.position.x, mob.transform.position.y, player.transform.position.z));
            }
            else 
            {
                speed.WalkSpeed = StandartWallkSpeed;
                speed.CrouchSpeed = StandartSitkSpeed;
                speed.SprintSpeed = StandartSprintSpeed;
                camera.fieldOfView = FieldOfViev;
            }
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
    }
}