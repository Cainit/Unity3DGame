using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof (ThirdPersonCharacter))]
public class AICharacterControl : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public ThirdPersonCharacter character { get; private set; } // the character we are controlling
    public Transform target;                                    // target to aim for
    public float AggroDist = 25;
    IKController ikController;

    bool aggro;

    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        ikController = GetComponent<IKController>();

        agent.updateRotation = false;
	    agent.updatePosition = true;
    }


    public void Aggro()
    {
        if (!aggro)
        {
            aggro = true;
        }
    }

    public void Disagro()
    {
        if(aggro)
        {
            aggro = false;
        }
    }

    private void Update()
    {
            

        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) <= AggroDist)
            {
                agent.SetDestination(target.position);
                Aggro();
            }
            else
            {
                Disagro();
                agent.SetDestination(transform.position);
            }
        }
        else
        {
            Disagro();
        }

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);

        if (ikController)
            ikController.ikActive = aggro;
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
