using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class BossAI : MonoBehaviour
    {
        [SerializeField] private GameObject aiController;


        private Animator anim;

        public UnityEngine.AI.NavMeshAgent
            agent { get; private set; } // the navmesh agent required for the path finding

        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target; // target to aim for


        private ThirdPersonCharacter tpc;
        private AIController aic;

        public int randomTarget;
        public int prevTarget = -1;

        public bool patrol;
        public bool chase;
        private bool cooldown;

        private void Start()
        {
            anim = GetComponent<Animator>();

            aic = aiController.GetComponent<AIController>();
            tpc = GetComponent<ThirdPersonCharacter>();

            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;
        }


        private void Update()
        {
            if (target != null)
            {
                agent.SetDestination(target.position);
            }
            
            target = aic.player.transform;


            if (Mathf.Abs((transform.position - target.transform.position).magnitude) > 0.1f &&
                target.gameObject == aic.player)
            {
                if (!anim.GetBool("Attack") && !cooldown)
                {
                    character.Move(agent.desiredVelocity, false, false);
                }
                else
                {
                    aic.player.GetComponent<PlayerHealth>().SubtractHealth();
                    cooldown = true;
                    target = transform;
                }
            }
        }
    }
}
