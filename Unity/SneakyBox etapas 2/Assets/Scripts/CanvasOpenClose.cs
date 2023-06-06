using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOpenClose : MonoBehaviour
{
	public GameObject canvasOpened;
	public GameObject canvasClosed;
	public GameObject button;

	// Start is called before the first frame update
	void Start()
    {
		canvasClosed.SetActive(true);
		canvasOpened.SetActive(false);
	}

	public void openOnPressed()
	{
		if (canvasClosed.activeInHierarchy == true)
		{
			canvasClosed.SetActive(false);
			canvasOpened.SetActive(true);
			button.SetActive(false);
		}

	}

	public void closeOnPressed()
	{
		if (canvasOpened.activeInHierarchy == true)
		{
			canvasOpened.SetActive(false);
			canvasClosed.SetActive(true);
			button.SetActive(true);
		}

	}
}
