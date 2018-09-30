using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	public void ExitGame()
	{
		Application.Quit();
	}

	public void goToSettings()
	{
		SceneManager.LoadScene(1);
	}

	public void goToNewCampaign()
	{
		SceneManager.LoadScene(2);
	}
}
