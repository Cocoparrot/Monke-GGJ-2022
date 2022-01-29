using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isObjective;
    public bool talks;

    public int[] emotion;
    public int emotionCount;
    private int emotionCountMax;
    public int successCount;

    private Movement movementSCR;
    private Manager gameManager;

    private void Start()
    {
        movementSCR = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        gameManager = Camera.main.GetComponent<Manager>();
    }

    private void Update()
    {
        if(emotionCount >= emotionCountMax)
        {
            movementSCR.talking = false;
        }
        if(successCount >= emotion.Length)
        {
            Debug.Log("Successfily talked");
            gameManager.objectivesCompleted += 1;
            successCount = 0;
        }
    }

    public void Interaction()
    {
        if (isObjective == true)
        {
            if (talks == true)
            {
                successCount = 0;
                Debug.Log("Talking");
                movementSCR.talking = true;
                emotionCountMax = emotion.Length;
                for (int i = 0; i < emotion.Length; i++)
                {
                    emotion[i] = Random.Range(1, 4);
                }
                movementSCR.talker = this.gameObject.GetComponent<Interactable>();
            }
            else
            {
                Debug.Log("Objective Complete");
                gameManager.objectivesCompleted += 1;
                
            }
        }
        else
        {
            Debug.Log("DISTRACTION");
        }
    }

    public void talkFail()
    {
        Debug.Log("Failed to talk");
        movementSCR.talking = false;
    }
}
