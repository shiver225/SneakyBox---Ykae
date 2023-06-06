using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public GameObject table1;
	public GameObject table2;
	public GameObject bed;
	public GameObject chair;
	public GameObject lamp;
	public GameObject hideTable1;
	public GameObject hideTable2;
	public GameObject hideBed;
	public GameObject hideChair;
	public GameObject hideLamp;
	public GameObject spawner;

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag.name == "Table1")
		{
			Instantiate(table1, spawner.transform.position, Quaternion.identity);
			hideTable1.SetActive(false);
		}
		else if (eventData.pointerDrag.name == "Table2")
		{
			Instantiate(table2, spawner.transform.position, Quaternion.identity);
			hideTable2.SetActive(false);
		}
		else if (eventData.pointerDrag.name == "Bed")
		{
			Instantiate(bed, spawner.transform.position, Quaternion.identity);
			hideBed.SetActive(false);
		}
		else if (eventData.pointerDrag.name == "Chair")
		{
			Instantiate(chair, spawner.transform.position, Quaternion.identity);
			hideChair.SetActive(false);
		}
		else if (eventData.pointerDrag.name == "Lamp")
		{
			Instantiate(lamp, spawner.transform.position, Quaternion.identity);
			hideLamp.SetActive(false);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
	//public void SwitchActiveState(GameObject item)
	//{
	//	item.SetActive(true);
	//}
}
