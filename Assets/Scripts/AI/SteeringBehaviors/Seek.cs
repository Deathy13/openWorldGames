using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


[CreateAssetMenu(fileName = "Seek",menuName = "SteeringBehavious/Seek",order = 1)]
public class Seek : SteeringBehaviour
{

          
    public float stoppingDistance = 1f;


    public override void OnDrawGizmosSelected(AI owner)
    {
        Gizmos.color = Color.blue;
        float distance = Vector3.Distance(owner.target.position, owner.transform.position);
        Gizmos.DrawWireSphere(owner.transform.position, distance - stoppingDistance);
    }

    public override Vector3 GetForce(AI owner)
    {
        // Create a value to return later
        Vector3 force = Vector3.zero;

        // get distance between owner and target
        float distance = Vector3.Distance(owner.transform.position, owner.target.position);
        if(distance > stoppingDistance)
        {
            if (owner.hasTarget)
            {
                // Get direction from AI agent to Target
                force += owner.target.position - owner.transform.position;
            }
        }
        // Modify value here...
        

        // Return value
        return force.normalized;
    }


}
