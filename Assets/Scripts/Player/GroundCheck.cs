using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Collider playerCollider;
    public Movement movementSCR;
    private bool grounded;

    private void Start()
    {
        movementSCR = this.gameObject.GetComponent<Movement>();
    }

    private void Update()
    {
        movementSCR.groundedPlayer = grounded;

    }

    private void OnCollisionStay(Collision other)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
