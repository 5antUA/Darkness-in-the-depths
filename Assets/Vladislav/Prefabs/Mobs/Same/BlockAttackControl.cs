using System.Collections;
using UnityEngine;

namespace mobs
{
    public class BlockAttackControl : MonoBehaviour
    {
        public float attackDistanse = 4;
        public float CorutineTime = 0.05f;

        protected GameObject player;
        protected Animator animator;
        protected MobDamager mobDamager;
        protected Monster monster;
        protected Player speed;
        protected Camera camera;
        protected CharacterController characterController;

        protected bool isattacking = false;
        protected float distance;
        protected float StandartWallkSpeed;
        protected float StandartCrouchSpeed;
        protected float StandartSprintSpeed;
        protected float FieldOfViev;
        [Header("\t PLAYER MODIFIKATION(IF NEED)")]
        public float ModifikatePlayerSpeed = 0;
        public float ModifikatePlayerFieldOfViev = 0;

        private void Start()
        {
            PlayerDataInit();
            monster = GetComponent<Monster>();
            animator = GetComponent<Animator>();
            mobDamager = GetComponent<MobDamager>();
        }

        private void Update()
        {
            Attack();
        }

        protected void PlayerDataInit()
        {
            player = GameObject.FindWithTag("Player");
            speed = player.GetComponent<Player>();
            camera = player.GetComponentInChildren<Camera>();
            characterController = player.GetComponent<CharacterController>();

            StandartWallkSpeed = speed.WalkSpeed;
            StandartCrouchSpeed = speed.CrouchSpeed;
            StandartSprintSpeed = speed.SprintSpeed;
            FieldOfViev = camera.fieldOfView;

            if (ModifikatePlayerSpeed == 0) ModifikatePlayerSpeed = speed.WalkSpeed;
            if (ModifikatePlayerFieldOfViev == 0) ModifikatePlayerFieldOfViev = camera.fieldOfView;
        }

        private void Attack()
        {
            distance = Vector3.Distance(this.transform.position, player.transform.position);
            if (distance < attackDistanse)
            {
                if (characterController.isGrounded && mobDamager.isdamage) PlayerModificationStart();

                if (!isattacking)
                {
                    isattacking = true;
                    StartCoroutine(routine: AttackControll());
                }

                this.transform.LookAt(new Vector3(player.transform.position.x,
                    this.transform.position.y, player.transform.position.z));

            }
            else PlayerModificationStop();
            if (monster.IsDead) PlayerModificationStop();
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

        public void PlayerModificationStart()
        {
            speed.WalkSpeed = ModifikatePlayerSpeed;
            speed.CrouchSpeed = ModifikatePlayerSpeed;
            speed.SprintSpeed = ModifikatePlayerSpeed;
            camera.fieldOfView = ModifikatePlayerFieldOfViev;
        }

        public void PlayerModificationStop()
        {
            speed.WalkSpeed = StandartWallkSpeed;
            speed.CrouchSpeed = StandartCrouchSpeed;
            speed.SprintSpeed = StandartSprintSpeed;
            camera.fieldOfView = FieldOfViev;
        }
    }
}