using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemTool : MonoBehaviour,IPointerClickHandler
{
	public string foodName;
	public int price = 0;

	private GameObject cartBoard;

	// Use this for initialization
	void Start()
	{
		cartBoard = GameObject.Find("CartArea");

	}

	// Update is called once per frame
	void Update()
	{

	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		Debug.Log(transform.name);
		if (transform.tag != "InCart" && cartBoard.transform.childCount < 22)
		{
			Instantiate(transform.gameObject, cartBoard.transform, false);

		}

		if (transform.tag == "InCart")
		{
			Destroy(transform.gameObject);

		}
	}
}
