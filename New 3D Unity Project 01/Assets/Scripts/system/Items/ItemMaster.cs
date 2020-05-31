using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemMaster : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler {
	public string itemName;
	public int price = 0;

	private GameObject cartBoard;
	private GameObject itemIntro;

	// Use this for initialization
	void Start() {
		cartBoard = GameObject.Find("CartArea");
	}

	// Update is called once per frame
	void Update() {

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

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (transform.tag != "InCart") 
		{
			//transform.GetChild(0).gameObject.SetActive(true);

		}

	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (transform.tag != "InCart") 
		{
			//transform.GetChild(0).gameObject.SetActive(false);

		}

	}
}
