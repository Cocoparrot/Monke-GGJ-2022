using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Melee : MonoBehaviour
{
    public Collider hitbox;
    public float swingTime;

    private bool activeMelee;
    private bool activeInteract;

    public Animator animator;

    public EventReference meleeVox;

    void Start()
    {
        activeMelee = false;
        activeInteract = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RuntimeManager.PlayOneShot(meleeVox);
            animator.SetTrigger("MAttack");
            StartCoroutine(SwingTime(swingTime));
        }

        if (Input.GetButtonDown("Interact"))
        {
            StartCoroutine(InteractTime(swingTime));
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Destructible>() && activeMelee == true)
        {
            Debug.Log("Smack");
            other.GetComponent<Destructible>().Destruction();
        }

        if (other.gameObject.GetComponent<Interactable>() && activeInteract == true)
        {
            Debug.Log("Interact");
            other.GetComponent<Interactable>().Interaction();
        }
    }

    IEnumerator SwingTime(float waitTime)
    {
        activeMelee = true;
        yield return new WaitForSeconds(waitTime);
        activeMelee = false;
    }

    IEnumerator InteractTime(float waitTime)
    {
        activeInteract = true;
        yield return new WaitForSeconds(waitTime);
        activeInteract = false;
    }
}
