using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {
	public bool allowUseItemHere;
	public GameObject[] slotsInBox;
	public GameObject[] items;
	public GameObject itemQuantity;
	public int[] ownItem;
    public Text shopMsg, itemMsg;
	public GameObject IM_ownItem;
	private int[] imo;

	private GameObject[] cloneItems;
	private GameObject[] cloneText;

    public GameObject cartBoard, shopBoard, boxBoard;

	// Use this for initialization
	void Start() {
        ownItem = new int[items.Length];
		imo = IM_ownItem.GetComponent<OwnItem>().ownItem;

		cloneItems = new GameObject[items.Length];
		cloneText = new GameObject[items.Length];

		for (int i = 0; i < items.Length; i++) 
		{
			items[i].GetComponent<ItemMaster>().itemNumber = i;
			//ownItem[i] = items[i].GetComponent<ItemMaster>().owned;
			ownItem[i] = imo[i];

			cloneItems[i] = Instantiate(items[i].gameObject, slotsInBox[i].transform, false);
			cloneText[i] = Instantiate(itemQuantity.gameObject, cloneItems[i].transform, false);
			cloneText[i].GetComponent<Text>().text = ownItem[i].ToString();

		}

        itemMsg.text = "";
		shopMsg.text = "";

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < items.Length; i++) 
		{
			cloneText[i].GetComponent<Text>().text = ownItem[i].ToString();
			Debug.Log(items[i].name + " own " + items[i].GetComponent<ItemMaster>().owned);
			imo[i] = ownItem[i];
		}
		
	}
}
