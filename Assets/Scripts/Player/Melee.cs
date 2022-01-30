using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Melee : MonoBehaviour
{
    public Collider hitbox;
    public float swingTime;
    public EventReference meleevox;

    private bool activeMelee;
    private bool activeInteract;

    void Start()
    {
        activeMelee = false;
        activeInteract = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RuntimeManager.PlayOneShot(meleevox);
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
