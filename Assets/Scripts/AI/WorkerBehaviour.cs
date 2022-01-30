using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using FMODUnity;

public class WorkerBehaviour : MonoBehaviour
{

    private Patrol patrol;
    private Transform[] targets;
    public Transform monkeyTarget;
    private GameObject lastSeen;

    private AI_Vision fov;

    private Movement movementSCR;

    public Animator animator;

    public EventReference spottedVox;

    public enum WorkerState
    {
        Unaware, Chase, Distracted
    }

    public WorkerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        movementSCR = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();

        currentState = WorkerState.Unaware;
        patrol = this.gameObject.GetComponent<Patrol>();
        fov = this.gameObject.GetComponent<AI_Vision>();
        targets = new Transform[patrol.targets.Length];
        for (int i = 0; i < patrol.targets.Length; i++)
        {
            targets[i] = patrol.targets[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            default:
            case WorkerState.Unaware:

                animator.SetBool("IsMoving", true);
                animator.SetBool("isAngry", false);

                patrol.targets = new Transform[targets.Length];
                for (int i = 0; i < patrol.targets.Length; i++)
                {
                    patrol.targets[i] = targets[i];
                }
                if (fov.visibleTargets[0] != null && movementSCR.form.speciesName == "Monkey")
                {
                    RuntimeManager.PlayOneShot(spottedVox);
                    currentState = WorkerState.Chase;
                }
                break;

            case WorkerState.Chase:

                animator.SetBool("isAngry", true);
                animator.SetBool("IsMoving", false);

                for (int i = 0; i < patrol.targets.Length; i++)
                {
                    patrol.targets[i] = null;
                }
                patrol.targets = new Transform[1];
                patrol.targets[0] = monkeyTarget;
                if (fov.visibleTargets.Count >= 1)
                {
                    monkeyTarget.position = fov.visibleTargets[0].position;
                }
                float dist = Vector3.Distance(monkeyTarget.position, this.transform.position);
                if (fov.visibleTargets.Count == 0 && dist <= 1.0f)
                {
                    patrol.targets = new Transform[1];
                    currentState = WorkerState.Unaware;
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
