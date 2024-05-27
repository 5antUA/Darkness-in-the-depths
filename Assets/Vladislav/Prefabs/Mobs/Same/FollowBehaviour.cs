using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace mobs
{
    public class FollowBehaviour : StateMachineBehaviour
    {
        public int ClipFollowNumber;

        public float walck_speed = 3.5f;
        public float attackDistanse = 4f;
        
        private GameObject player;
        private NavMeshAgent agent;

        private Sounds sounds;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
        }
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent = animator.gameObject.GetComponent<NavMeshAgent>();
            agent.speed = walck_speed;
            agent.stoppingDistance = attackDistanse;
            sounds = animator.GetComponent<Sounds>(); 
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent.SetDestination(player.transform.position);

            if (!sounds.isplaying)
                sounds.PlaySound(sounds.sounds[ClipFollowNumber],p1:0.9f,p2:1.1f,volume:3);

        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            sounds.StopSound();
            agent.SetDestination(animator.transform.position);
        }
    }
}