using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    public bool hasTarget;



    [ShowIf("hasTarget")] public Transform target;
    public float maxVelocity = 15f, maxDistance = 10f;
    
    [Expandable]
    public SteeringBehaviour[] behaviours;
    public NavMeshAgent agent;

    private Vector3 velocity;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 desiredPosition = transform.position + velocity * Time.deltaTime;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(desiredPosition, .1f);


        foreach (var behaviour in behaviours)
        {
            behaviour.OnDrawGizmosSelected(this);
        }
    }

    private void Update()
    {
        velocity = Vector3.zero;
        // Step 1). Loop through all behaviours and get forces
        foreach (var behaviour in behaviours)
        {
            //apply normalized force to force
            float percentage = maxVelocity * behaviour.weightung;
            velocity += behaviour.GetForce(this) * percentage;
        }
        // Step 2). Limit velocity to max velocity
        velocity = Vector3.ClampMagnitude(velocity, maxVelocity);
        // Step 3). Apply velocity to NavMeshAgent destination
        Vector3 desiredPosition = transform.position + velocity * Time.deltaTime;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(desiredPosition, out hit, maxDistance, -1))
        {
            agent.SetDestination(hit.position);

        }
    }
}
