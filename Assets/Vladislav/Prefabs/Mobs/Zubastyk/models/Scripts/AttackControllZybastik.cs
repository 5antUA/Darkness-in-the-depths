using UnityEngine;

namespace mobs
{
    public class AttackControllZybastik : AttackControl
    {
        private Player speed;
        private Camera camera;
        private float StandartWallkSpeed;
        private float StandartSprintSpeed;
        private float FieldOfViev;
        public override void Awake()
        {
            mob = gameObject;
        }
        private void Update()
        {
            Init();
            Attack();
        }
        private void OnDestroy()
        {
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
                camera.fieldOfView = 26;
                EventManager.ShowDamageScreen();
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