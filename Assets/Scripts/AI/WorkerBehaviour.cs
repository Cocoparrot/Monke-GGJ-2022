using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WorkerBehaviour : MonoBehaviour
{

    private Patrol patrol;
    private Transform[] targets;
    public Transform monkeyTarget;
    private GameObject lastSeen;

    private AI_Vision fov;
    

    public enum WorkerState
    {
        Unaware, Chase, Distracted
    }

    private WorkerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        fov = gameObject.GetComponent<AI_Vision>();
        targets = patrol.targets;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            default:
            case WorkerState.Unaware:
                patrol.targets = targets;
                break;
            case WorkerState.Chase:
                for (int i = 0; i < patrol.targets.Length; i++)
                {
                    patrol.targets[i] = null;
                }

                patrol.targets[0] = monkeyTarget;
                if (fov.visibleTargets[0] != null)
                {
                    monkeyTarget.position = fov.visibleTargets[0].position;
                }
                break;
                //Distracted makes it so the worker waits for 5 seconds on the waypoint of the distraction?
            case WorkerState.Distracted:
                //Came across a distraction and now he will just wait
                patrol.delay = 5;
                break;
        }
    }

}
