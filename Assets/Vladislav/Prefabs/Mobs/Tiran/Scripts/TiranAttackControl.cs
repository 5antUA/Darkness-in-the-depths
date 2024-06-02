using System.Collections;
using UnityEngine;

namespace mobs
{
    public class TiranAttackControl : AttackControllZybastik
    {
        private Monster monster;
        private ParticleSystem particleSystem;

        public override void Awake()
        {
            mob = gameObject;
            monster = GetComponent<Monster>();
            animator = GetComponent<Animator>();
            particleSystem = GetComponentInChildren<ParticleSystem>();
        }
        private void Update()
        {
            Init();
            Attack();
        }
        private void OnDestroy()
        {
            particleSystem.Play();
            speed.WalkSpeed = StandartWallkSpeed;
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
                StandartSprintSpeed = speed.SprintSpeed;
                FieldOfViev = camera.fieldOfView;
            }
        }
        private void Attack()
        {
            distance = Vector3.Distance(mob.transform.position, player.transform.position);
            if (distance < attackDistanse)
            {
                speed.WalkSpeed = 0.1f;
                speed.SprintSpeed = 0.1f;
                camera.fieldOfView = 37;                     
                player.transform.LookAt(new Vector3(mob.transform.position.x, player.transform.position.y, mob.transform.position.z));
                if (!isattacking)
                {
                    isattacking = true;
                    StartCoroutine(routine: AttackControll());
                }
            }
        }
        public void Push() {
            player.GetComponent<CharacterController>().Move(new Vector3(player.transform.position.x,
             player.transform.position.y, player.transform.position.z - 100) * Time.deltaTime);
        }
        public override IEnumerator AttackControll()
        {
            animator.SetBool("Attack", true);
            yield return new WaitForSeconds(CorutineTime);
            EventManager.ShowDamageScreen();
            Push();
            yield return new WaitForSeconds(CorutineTime);
            monster.TakeDamage(9999999f);
        }

    }
}