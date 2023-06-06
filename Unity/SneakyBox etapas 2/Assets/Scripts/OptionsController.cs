using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
	public GameObject optionsOpened;
	public GameObject optionsClosed;


	private void Start()
	{
		optionsOpened.SetActive(false);
		optionsClosed.SetActive(true);
	}

	public void openOnPress()
	{
		if (optionsOpened.activeInHierarchy == false)
		{
			optionsOpened.SetActive(true);
			optionsClosed.SetActive(false);
		}
			
	}

	public void closeOnPress()
	{
		if (optionsOpened.activeInHierarchy == true)
		{
			optionsOpened.SetActive(false);
			optionsClosed.SetActive(true);
		}
			
	}
}
