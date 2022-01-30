using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	//public Animator transition;
	//public float transitionTime = 1f;

	public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene(sceneBuildIndex: 0);
	}
	
	

	public void QuitGame()
	{
		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false;
	}
}
