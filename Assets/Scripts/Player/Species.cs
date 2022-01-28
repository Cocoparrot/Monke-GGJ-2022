using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Species", order = 1)]
public class Species : ScriptableObject
{
    public string speciesName;

    public float speed;
    public float jumpSpeed;
}
