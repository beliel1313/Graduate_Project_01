using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemMaster : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler {
	public int itemNumber;
	public string itemName;
	public int price = 0;
	public int owned;

	private GameObject itemsManager;
	private GameObject cartBoard;
    private GameObject shopBoard;
    static public Vector2 itemPos;
	private GameObject shopMsg, itemMsg;
	private Text shopMsgText, itemMsgText;

	private GameObject boxBoard;

	// Use this for initialization
	void Start() {
		itemsManager = GameObject.Find("ItemManager");
		cartBoard = GameObject.Find("CartArea");
        shopBoard = GameObject.Find("ShopBoard");
		boxBoard = GameObject.Find("ItemBoxGroup");

		shopMsg = GameObject.Find("ShopMsg");
		//shopMsg.GetComponent<Text>().text = "";

		itemMsg = GameObject.Find("ItemMsg");
		//itemMsg.GetComponent<Text>().text = "";

	}

	// Update is called once per frame
	void Update() {
		owned = itemsManager.GetComponent<ItemManager>().ownItem[itemNumber];

		if (boxBoard != null) 
		{
			if (transform.IsChildOf(boxBoard.transform) && owned == 0)
			{
				transform.GetComponent<Image>().color = Color.gray;

			}
			else if (transform.IsChildOf(boxBoard.transform) && owned > 0)
			{
				transform.GetComponent<Image>().color = Color.white;

			}

		}

	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		Debug.Log(transform.name);
		if (shopBoard != null && transform.IsChildOf(shopBoard.transform) && cartBoard.transform.childCount < 22) 
		{
			Instantiate(transform.gameObject, cartBoard.transform, false);
		}

		if (cartBoard != null && transform.IsChildOf(cartBoard.transform)) 
		{
			Destroy(transform.gameObject);
		}

		if (boxBoard != null && transform.IsChildOf(boxBoard.transform) && owned > 0) 
		{
			itemsManager.GetComponent<ItemManager>().ownItem[itemNumber] -= 1;
			itemMsgText.text = "使用了  " + itemName;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		shopMsgText = shopMsg.GetComponent<Text>();
		itemMsgText = itemMsg.GetComponent<Text>();

		if (shopMsg != null) 
		{
			if (transform.IsChildOf(shopBoard.transform) || transform.IsChildOf(cartBoard.transform)) 
			{
				shopMsgText.text = itemName + "  " + price + " 元";
			}

		}

		if (itemMsg != null && transform.IsChildOf(boxBoard.transform)) 
		{
			itemMsgText.text = itemName;
		}

	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (shopMsg != null) 
		{
			shopMsgText.text = "";
		}

	}
}
