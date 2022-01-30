using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class ComicSwitcher : MonoBehaviour
{

    public Animator animator;

    public int panelCount;

    public string[] cam;

    public EventReference[] comicLines;

    // Start is called before the first frame update
    void Start()
    {
        panelCount = 1;
        animator = GetComponent<Animator>();
        RuntimeManager.PlayOneShot(comicLines[0]);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PanelSwitch();
        }
    }
    // Update is called once per frame
    void PanelSwitch()
    {
        if (panelCount <= 7)
        {
            animator.Play(cam[panelCount]);
            RuntimeManager.PlayOneShot(comicLines[panelCount]);
        }
        panelCount += 1;
        if (panelCount >= 9)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
