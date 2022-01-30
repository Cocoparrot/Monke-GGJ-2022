using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    public Movement movementSCR;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hit");
        if(collision.gameObject.tag == "Player")
        {
            
            movementSCR = collision.gameObject.GetComponent<Movement>();
            if(movementSCR.form.speciesName == "Monkey")
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
