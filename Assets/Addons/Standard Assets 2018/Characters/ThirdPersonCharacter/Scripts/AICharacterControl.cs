using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        [SerializeField] private GameObject cursorObj;
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Vector3 target;                                    // target to aim for

        private bool cooldown;
        private RaycastHit hit;
        private TextReader textReader;

        private bool targetIsInteractable;
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            // agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (target == Vector3.zero)
            {
                target = transform.position;
            }
            

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && GameManager.IsMoveable)
            {
                switch (hit.collider.tag)
                {
                    case "Ground":
                        target = new Vector3(hit.point.x, 0, hit.point.z);
                        agent.SetDestination(target);
                        break;
                    
                    case "Interactable":
                        Interactable interactable = hit.collider.GetComponent<Interactable>();
                        textReader = hit.collider.GetComponent<TextReader>();
                        print("INTERACTED WITH" + hit.collider.name);

                        // if (interactable.isinteracted)
                        {
                            target = interactable.targetLocation.transform.position;
                            agent.SetDestination(target);
                            targetIsInteractable = true;
                            
                            //Send action to Text reader script to initialize dialogue but not display yet
                        }
                        break;
                }
            }
                
            // print(agent.isStopped);

            // print(agent.remainingDistance);
            if (agent.remainingDistance > 0.3f)
            {
                // print(Mathf.Abs((transform.position - target).magnitude));
                character.Move(agent.desiredVelocity, false, false);

                if (agent.remainingDistance < 0.7f && textReader != null && targetIsInteractable)
                {
                    textReader.ToggleUI();
                    targetIsInteractable = false;
                    // Send action to Text reader to enable UI
                    print("ENABLE UI");
                } 
            }
            else
            {
                  
            }
        }
    }
}
