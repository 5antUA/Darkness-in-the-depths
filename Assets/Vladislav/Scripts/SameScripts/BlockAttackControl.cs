using System.Collections;
using UnityEngine;

namespace mobs
{
    public class BlockAttackControl : MonoBehaviour
    { 
        public float attackDistanse = 4;        //дистанція для атаки
        public float CorutineTime = 0.05f;      //час до початку атаки

        //данні для взаємодії
        protected GameObject player;            
        protected Animator animator;
        protected MobDamager mobDamager;
        protected Monster monster;
        protected Player speed;
        protected Camera camera;
        protected CharacterController characterController;

        protected bool isattacking = false;     //флажок стану атаки

        protected float distance;               //дистанція для вирахування
        //властивості плеєра(для модифікації)
        protected float StandartWallkSpeed;
        protected float StandartCrouchSpeed;
        protected float StandartSprintSpeed;
        protected float FieldOfViev;

        [Header("\t PLAYER MODIFIKATION(IF NEED)")]
        //модифікаційні данні(залежать від монстра)
        public float ModifikatePlayerSpeed = 0;
        public float ModifikatePlayerFieldOfViev = 0;

        //ініціялізація данних
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

        //ініціалізація данних плеєра
        protected void PlayerDataInit()
        {
            player = GameObject.FindWithTag("Player");
            speed = player.GetComponent<Player>();
            camera = player.GetComponentInChildren<Camera>();
            characterController = player.GetComponent<CharacterController>();

            //ініціялізація поточних властивостей плеєра
            StandartWallkSpeed = speed.WalkSpeed;
            StandartCrouchSpeed = speed.CrouchSpeed;
            StandartSprintSpeed = speed.SprintSpeed;
            FieldOfViev = camera.fieldOfView;
            
            //у випадку якщо модивікації не застосовуються
            if (ModifikatePlayerSpeed == 0) ModifikatePlayerSpeed = speed.WalkSpeed;
            if (ModifikatePlayerFieldOfViev == 0) ModifikatePlayerFieldOfViev = camera.fieldOfView;
        }

        //логіка атаки
        private void Attack()
        {
            distance = Vector3.Distance(this.transform.position, player.transform.position);//розрахування дистанції
            if (distance < attackDistanse)
            {
                if (characterController.isGrounded && mobDamager.isdamage) PlayerModificationStart();//початок модифікацій

                if (!isattacking)//початок атаки
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

        //контроллер атаки
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

        //функція початку модифікацій
        public void PlayerModificationStart()
        {
            speed.WalkSpeed = ModifikatePlayerSpeed;
            speed.CrouchSpeed = ModifikatePlayerSpeed;
            speed.SprintSpeed = ModifikatePlayerSpeed;
            camera.fieldOfView = ModifikatePlayerFieldOfViev;
        }

        //функція початку закінчення
        public void PlayerModificationStop()
        {
            speed.WalkSpeed = StandartWallkSpeed;
            speed.CrouchSpeed = StandartCrouchSpeed;
            speed.SprintSpeed = StandartSprintSpeed;
            camera.fieldOfView = FieldOfViev;
        }
    }
}