using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuCotroller : MonoBehaviour
{
	[SerializeField] private string newGameLevel;

	public void NewGameButton()
	{
		SceneManager.LoadScene(newGameLevel);
	}

	public void LoadGameButton()
	{
		if (PlayerPrefs.HasKey("LevelSaved"))
		{
			string levelToLoad = PlayerPrefs.GetString("LevelSaved");
			SceneManager.LoadScene(levelToLoad);
		}
	}

	public void MainMenuButton()
	{
		SceneManager.LoadScene("StartMenu");
	}
}
