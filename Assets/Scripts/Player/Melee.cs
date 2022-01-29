using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Collider hitbox;
    public bool active;
    public float swingTime;

    void Start()
    {
        active = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(SwingTime(swingTime));
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Destructible>() && active == true)
        {
            Debug.Log("Smack");
            other.GetComponent<Destructible>().Destruction();
        }
    }

    IEnumerator SwingTime(float waitTime)
    {
        active = true;
        yield return new WaitForSeconds(waitTime);
        active = false;
    }
}
