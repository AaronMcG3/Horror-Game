using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSimplePatrol : MonoBehaviour {

    [SerializeField] bool patrolWiting;

    [SerializeField] float totalWaitTime = 3f;

    [SerializeField] float switchProbabilty = 0.2f;

    [SerializeField] List<Waypoint> patrolPoints;

    NavMeshAgent navMeshAgents;
    int currentPatrolIndex;
    bool travelling;
    bool waiting;
    bool patrolForward;
    float waitTimer;

	// Use this for initialization
	void Start () {

        navMeshAgents = this.GetComponent<NavMeshAgent>();

        if(patrolPoints != null && patrolPoints.Count >= 2)
        {
            currentPatrolIndex = 0;
            SetDestination();
        }

	}

    // Update is called once per frame
    void Update () {
		if(travelling && navMeshAgents.remainingDistance <= 1.0f)
        {
            travelling = false;

            if (patrolWiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer >= totalWaitTime)
            {
                waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
	}

    private void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= switchProbabilty)
            patrolForward = !patrolForward;

        if (patrolForward)
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        else
        {
            if (--currentPatrolIndex < 0)
                currentPatrolIndex = patrolPoints.Count - 1;
        }
    }

    private void SetDestination()
    {
        if(patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            navMeshAgents.SetDestination(targetVector);
            travelling = true;
        }
    }
}
