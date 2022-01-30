using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int objectiveNum;
    public int objectivesCompleted = 0;
    public GameObject[] levels;

    void Awake()
    {
        LevelLoad();
    }

    void Update()
    {
        if(objectivesCompleted >= objectiveNum && objectiveNum != 0)
        {
            Debug.Log("Win Game");
        }
    }

    void LevelLoad()
    {
        int level = Random.Range(0, levels.Length);
        //Instantiate(levels[level], new Vector3(0f, 0f, 0f), Quaternion.identity);
        objectiveNum = GameObject.FindGameObjectsWithTag("Objective").Length;
    }
}
