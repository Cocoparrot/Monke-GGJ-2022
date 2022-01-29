using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public int multiplier;
    public int monkeyMeter;
    public int monkeyMeterMax;

    public float multiplierDuration;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0;
        multiplier = 1;
    }

    void Update()
    {
        if(monkeyMeter == monkeyMeterMax)
        {
            MonkeyMeter();
        }
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
        scoreText.SetText("X{1} Score: {0}", score, multiplier);
    }

    public void addMultiplier(int added)
    {
        multiplier += added;
        scoreText.SetText("X{1} Score: {0}", score, multiplier);
        StartCoroutine(MultiplierDuration(multiplierDuration));
    }

    IEnumerator MultiplierDuration(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        multiplier = 1;
    }

    public void MonkeyMeter()
    {
        addScore(400, false);
        addMultiplier(1);
        monkeyMeter = 0;
    }
}
