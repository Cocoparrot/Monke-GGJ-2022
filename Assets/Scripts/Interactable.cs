using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isObjective;

    public void Interaction()
    {
        if (isObjective == true)
        {
            Debug.Log("Objective Complete");
        }
        else
        {
            Debug.Log("DISTRACTION");
        }
    }
}
