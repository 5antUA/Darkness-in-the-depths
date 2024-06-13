using UnityEngine;
using UnityEngine.AI;

namespace mobs
{
    public class FollowBehaviour : StateMachineBehaviour
    {
        public float walck_speed = 3.5f;        //швидкість монстра
        public float attackDistanse = 4f;       //дистанція для повної зупинки

        //данні для взаємодії
        private GameObject player;              
        private NavMeshAgent agent;
        private Sounds sounds;

        //змінна для відтворення звуку
        public int ClipFollowNumber;

        //ініціалізація
        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
        }

        //ініціалізація об'єктів (якщо спрацьовує стан переслірування)
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (player == null)
                player = GameObject.FindWithTag("Player");
            
                agent = animator.gameObject.GetComponent<NavMeshAgent>();
                agent.speed = walck_speed;
                agent.stoppingDistance = attackDistanse;
                sounds = animator.GetComponent<Sounds>();            
        }

        //самафункція переслідування за допомогою навігації
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent.SetDestination(player.transform.position);

            if (!sounds.isplaying)
                sounds.PlaySound(sounds.sounds[ClipFollowNumber], p1: 0.9f,p2: 1.1f, volume: 3);
        }

        //вихід зі стану
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            sounds.StopSound();
            agent.SetDestination(animator.transform.position);//зупинка на місці
        }
    }
}