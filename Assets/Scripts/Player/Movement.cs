using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public Transform cam;
    public StudioEventEmitter emitter;

    public Species human;
    public Species monkey;
    public Species form;
    public GameObject humanGFX;
    public GameObject monkeyGFX;

    public Melee melee;

    private void Start()
    {
        playerSpeed = form.speed;
        jumpHeight = form.jumpSpeed;
        melee.swingTime = form.swingTime;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        formSwap();
    }

    void movement()
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * Time.deltaTime * playerSpeed);
        }
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void formSwap()
    {
        if (Input.GetButtonDown("Swap"))
        {
            
            Debug.Log("Swap");
            if (form.speciesName == "Monkey")
            {
                form = human;
                monkeyGFX.SetActive(false);
                humanGFX.SetActive(true);
                emitter.SetParameter("Monkey Mode", 1);
            }
            else
            {
                form = monkey;
                monkeyGFX.SetActive(true);
                humanGFX.SetActive(false);
                emitter.SetParameter("Monkey Mode", 51);
            }

            playerSpeed = form.speed;
            jumpHeight = form.jumpSpeed;
            melee.swingTime = form.swingTime;
        }
    }
}
