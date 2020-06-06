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
	private Text goodInfo;

	// Use this for initialization
	void Start() {
		itemsManager = GameObject.Find("ItemManager");
		cartBoard = GameObject.Find("CartArea");
        shopBoard = GameObject.Find("ShopBoard");
		goodInfo = GameObject.Find("GoodInfo").GetComponent<Text>();
		if (goodInfo != null) goodInfo.text = "";

	}

	// Update is called once per frame
	void Update() {
		owned = itemsManager.GetComponent<ItemManager>().ownItem[itemNumber];

	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		Debug.Log(transform.name);
		if (transform.IsChildOf(shopBoard.transform) && cartBoard.transform.childCount < 22) 
		{
			Instantiate(transform.gameObject, cartBoard.transform, false);

		}

		if (transform.IsChildOf(cartBoard.transform)) 
		{
			Destroy(transform.gameObject);

		}

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (goodInfo != null) 
		{
			goodInfo.text = itemName + "  " + price + " 元";

		}

	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (goodInfo != null) goodInfo.text = "";

	}
}
