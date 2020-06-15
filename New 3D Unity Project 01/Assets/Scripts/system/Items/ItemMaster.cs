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
	private GameObject boxBoard;

	// Use this for initialization
	void Start() {
		itemsManager = GameObject.Find("ItemManager");
		cartBoard = GameObject.Find("CartArea");
        shopBoard = GameObject.Find("ShopBoard");
		boxBoard = GameObject.Find("ItemBoxGroup");

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

        if (transform.IsChildOf(boxBoard.transform) && owned > 0) 
        {
            itemsManager.GetComponent<ItemManager>().ownItem[itemNumber] -= 1;
            itemsManager.GetComponent<ItemManager>().itemMsg.text = "使用了  " + itemName;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
	{
        if (transform.IsChildOf(cartBoard.transform) || transform.IsChildOf(shopBoard.transform))
        {
            itemsManager.GetComponent<ItemManager>().shopMsg.text = itemName + "  " + price.ToString() + " 元";
        }
        else transform.IsChildOf(boxBoard.transform);
        {
            itemsManager.GetComponent<ItemManager>().itemMsg.text = "" + itemName;
        }

        if (transform.IsChildOf(boxBoard.transform)) 
        {
            //itemsManager.GetComponent<ItemManager>().itemMsg.text = "" + itemName;
        }


    }

    public void OnPointerExit(PointerEventData eventData)
	{
        itemsManager.GetComponent<ItemManager>().shopMsg.text = "";
        itemsManager.GetComponent<ItemManager>().itemMsg.text = "";
    }
}
