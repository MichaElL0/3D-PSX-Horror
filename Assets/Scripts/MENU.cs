using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
   public void SwitchScene()
	{
		SceneManager.LoadScene("intro");
	}

	public void Quit()
	{
		Application.Quit();
		print("QUIT");
	}

	public void Restart()
	{
		SceneManager.LoadScene("The game");
	}

	public void LoadScene()
	{
		SceneManager.LoadScene("The game");
	}


}
