using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WorkerBehaviour : MonoBehaviour
{

    private Patrol patrol;
    private Transform[] targets;
    private GameObject lastSeen;
    

    public enum WorkerState
    {
        Unaware, Chase, Distracted
    }

    private WorkerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        targets = patrol.targets;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case WorkerState.Unaware:
                patrol.targets = targets;
                break;
            case WorkerState.Chase:
                for(int i = 0; i < patrol.targets.Length; i++)
                {
                    patrol.targets[i] = null;
                }
                patrol.targets = lastSeen.transform;
                break;
                //Distracted makes it so the worker waits for 5 seconds on the waypoint of the distraction?
            case WorkerState.Distracted:
                //Came across a distraction and now he will just wait
                patrol.delay = 5;
                break;
        }
    }

}
