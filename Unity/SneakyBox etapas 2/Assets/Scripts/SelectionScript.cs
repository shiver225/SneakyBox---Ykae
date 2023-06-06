using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionScript : MonoBehaviour
{
	public Material highlightMaterial;
	public Material selectionMaterial;

	private Material originalMaterialHighlight;
	private Material originalMaterialSelection;
	private Transform highlight;
	private Transform selection;
	private RaycastHit raycastHit;


	public GameObject item;	
	public string inventorySlotName;

	private static GameObject canvas;


	private void Awake()
	{
		if (canvas == null)
		{
			canvas = GameObject.FindGameObjectWithTag("inventory");
		}
	}

	void Update()
	{
		// Highlight
		if (highlight != null)
		{
			highlight.GetComponent<MeshRenderer>().sharedMaterial = originalMaterialHighlight;
			highlight = null;
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
		{
			highlight = raycastHit.transform;
			if (highlight.CompareTag("drag") && highlight != selection)
			{
				if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
				{
					originalMaterialHighlight = highlight.GetComponent<MeshRenderer>().material;
					highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
				}
			}
			else
			{
				highlight = null;
			}
		}

		// Selection
		if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
		{
			if (highlight)
			{
				if (selection != null)
				{
					selection.GetComponent<MeshRenderer>().material = originalMaterialSelection;
				}
				selection = raycastHit.transform;
				if (selection.GetComponent<MeshRenderer>().material != selectionMaterial)
				{
					
					originalMaterialSelection = originalMaterialHighlight;
					selection.GetComponent<MeshRenderer>().material = selectionMaterial;
					Debug.Log(selection.GetComponent<MeshRenderer>().material.name);
				}

				highlight = null;
			}
			else
			{
				if (selection)
				{
					selection.GetComponent<MeshRenderer>().material = originalMaterialSelection;
					selection = null;
				}
			}
		}

		// Deletion
		if (selection.GetComponent<MeshRenderer>().material.name == "SelectionMat (Instance)" && Input.GetKey(KeyCode.E))
		{
			Destroy(item);
			if (canvas != null && !string.IsNullOrEmpty(inventorySlotName))
			{
				if (canvas != null && !string.IsNullOrEmpty(inventorySlotName))
				{
					// Search for the grid object within the canvas
					Transform gridTransform = canvas.transform.Find("Grid");
					if (gridTransform != null)
					{
						// Search for the inventory slot within the grid
						Transform inventorySlotTransform = gridTransform.Find(inventorySlotName);
						if (inventorySlotTransform != null)
						{
							GameObject inventorySlot = inventorySlotTransform.gameObject;
							inventorySlot.SetActive(true);
						}
					}
				}
			}
		}

	}
}
