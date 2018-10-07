using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour {

    [SerializeField] private Transform destination;

    NavMeshAgent navMeshAgent;

    // Use this for initialization
    void Start () {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        SetDestination();
	}

    private void SetDestination()
    {
        if(destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }

    }
}
