using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Collider playerCollider;
    public Movement movementSCR;
    private float distToGround;

    private void Start()
    {
        playerCollider = this.gameObject.GetComponent<Collider>();
        movementSCR = this.gameObject.GetComponent<Movement>();
        distToGround = playerCollider.bounds.extents.y;
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 1f);
    }

    private void Update()
    {
        if (IsGrounded())
        {
            movementSCR.groundedPlayer = true;
        }
        else
        {
            movementSCR.groundedPlayer = false;
        }
    }
}
