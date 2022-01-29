using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public int multiplier;

    public float multiplierDuration;

    void Start()
    {
        score = 0;
        multiplier = 1;
    }

    public void addScore(int added)
    {
        score += (added * multiplier);
    }

    public void addMultiplier(int added)
    {
        multiplier += added;
        StartCoroutine(MultiplierDuration(multiplierDuration));
    }

    IEnumerator MultiplierDuration(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        multiplier = 1;
    }
}
