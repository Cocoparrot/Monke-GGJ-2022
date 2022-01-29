using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject brokenModel;
    public int score;
    private Score scoreSCR;

    void Start()
    {
        scoreSCR = Camera.main.GetComponent<Score>();
    }

    public void Destruction()
    {
        scoreSCR.addScore(score);
        //Instantiate(brokenModel, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
