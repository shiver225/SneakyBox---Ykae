using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameDrag : MonoBehaviour
{
	private Vector3 mOffset;
	private float mZCoord;
	private float mXCoord;
	Rigidbody rb;
	public float speed = 2.0f;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void OnMouseDown()
	{
		mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		transform.position = GetMouseworldPos();
		//mXCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).x;
		//mOffset = gameObject.transform.position - GetMouseworldPos();
	}

	private Vector3 GetMouseworldPos()
	{
		Vector3 mousePoint = Input.mousePosition;
		mousePoint.z = mZCoord;
		//mousePoint.x = mXCoord;

		return Camera.main.ScreenToWorldPoint(mousePoint);
	}

	void OnMouseDrag()
	{

		//transform.position = GetMouseworldPos();
		transform.rotation = Quaternion.identity;

		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			transform.Translate(Input.GetAxis("Mouse ScrollWheel") * speed * transform.forward - GetMouseworldPos());
		}
		//if (Input.GetAxis("Mouse ScrollWheel") < 0)
		//{
		//	transform.Translate(Input.GetAxis("Mouse ScrollWheel") * transform.forward + transform.right);
		//}


			rb.isKinematic = true;
	}

	private void OnMouseUp()
	{
		rb.isKinematic = false;
	}
}
