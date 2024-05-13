using UnityEngine;
using UnityEngine.AI;

namespace mobs
{
    public class FollowBehaviour : StateMachineBehaviour
    {
        private GameObject player;
        private NavMeshAgent agent;
        public float walck_speed = 3.5f;
        public float attackDistanse = 4f;
        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
        }
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent = animator.gameObject.GetComponent<NavMeshAgent>();
            agent.speed = walck_speed;
            agent.stoppingDistance = attackDistanse;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent.SetDestination(player.transform.position);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent.SetDestination(animator.transform.position);
        }
    }
}