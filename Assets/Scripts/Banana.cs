using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private Score scoreSCR;

    void Start()
    {
        scoreSCR = Camera.main.GetComponent<Score>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            scoreSCR.monkeyMeter = scoreSCR.monkeyMeterMax;
            Destroy(this.gameObject);
        }
    }
}
