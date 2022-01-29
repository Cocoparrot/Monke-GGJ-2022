using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public int multiplier;
    public int monkeyMeter;
    public int monkeyMeterMax;

    public float multiplierDuration;

    void Start()
    {
        score = 0;
        multiplier = 1;
    }

    public void addScore(int added, bool multiply)
    {
        if (multiply == true)
        {
            score += (added * multiplier);
        }
        else
        {
            score += added;
        }
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

    void MonkeyMeter()
    {
        if (monkeyMeter == monkeyMeterMax)
        {
            addScore(400, false);
            addMultiplier(1);
        }
    }
}
