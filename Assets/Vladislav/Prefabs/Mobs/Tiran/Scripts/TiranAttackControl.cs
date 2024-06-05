using System.Collections;
using UnityEngine;

namespace mobs
{
    public class TiranAttackControl : BlockAttackControl
    {

        private ParticleSystem particleSystem;

        private void Start()
        {
            monster = GetComponent<Monster>();
            animator = GetComponent<Animator>();
            particleSystem = GetComponentInChildren<ParticleSystem>();
            PlayerDataInit();
        }
        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            distance = Vector3.Distance(this.transform.position, player.transform.position);
            if (distance < attackDistanse)
            {
                if (characterController.isGrounded)
                {
                    speed.WalkSpeed = 0.01f;
                    speed.SprintSpeed = 0.01f;
                    speed.CrouchSpeed = 0.01f;
                    camera.fieldOfView = 40;
                }
                player.transform.LookAt(new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z));
                if (!isattacking)
                {
                    isattacking = true;
                    StartCoroutine(routine: AttackControll());
                }
            }
            else PlayerModificationStop();
            if (monster.IsDead)
            {
                PlayerModificationStop();
                particleSystem.Play();
            }
        }
        public void Push()
        {
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