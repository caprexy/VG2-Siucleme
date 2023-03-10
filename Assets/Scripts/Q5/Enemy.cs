using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPS { 
public class Enemy : MonoBehaviour
{
        NavMeshAgent navAgent;

        public Transform priorityTarget;
        public Transform target;
        public Transform patrolRoute;

        int patrolIndex;
        public float chaseDistance;
    // Start is called before the first frame update
    void Start()
    {
            navAgent = GetComponent<NavMeshAgent>();
            patrolIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
            if (patrolRoute)
            {
                target = patrolRoute.GetChild(patrolIndex);

                float distance = Vector3.Distance(transform.position, target.position);
                print("distance: " + distance);

                if(distance <= 1.5f)
                {
                    patrolIndex++;
                    if(patrolIndex>= patrolRoute.childCount)
                    {
                        patrolIndex = 0;
                    }
                }

            }
            if (priorityTarget)
            {
                float prioTargetDist = Vector3.Distance(transform.position, priorityTarget.position);

                if(prioTargetDist <= chaseDistance)
                {
                    target = priorityTarget;
                    GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {
                    GetComponent<Renderer>().material.color = Color.white;
                }
            }
            if (target)
            {
                navAgent.SetDestination(target.position);
            }
        
    }
}
}
