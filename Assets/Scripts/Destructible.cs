using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject brokenModel;

    public void Destruction()
    {
        Instantiate(brokenModel, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
