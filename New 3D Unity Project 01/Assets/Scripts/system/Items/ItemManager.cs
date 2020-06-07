using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {
	public GameObject[] slots;
	public GameObject[] items;
	public GameObject itemQuantity;
	public int[] ownItem;

	private GameObject[] cloneItems;
	private GameObject[] cloneText;

	// Use this for initialization
	void Start() {
		ownItem = new int[items.Length];
		cloneItems = new GameObject[items.Length];
		cloneText = new GameObject[items.Length];

		for (int i = 0; i < items.Length; i++) 
		{
			items[i].GetComponent<ItemMaster>().itemNumber = i;
			ownItem[i] = items[i].GetComponent<ItemMaster>().owned;

			cloneItems[i] = Instantiate(items[i].gameObject, slots[i].transform, false);
			cloneText[i] = Instantiate(itemQuantity.gameObject, cloneItems[i].transform, false);
			cloneText[i].GetComponent<Text>().text = ownItem[i].ToString();

		}

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < items.Length; i++) 
		{
			cloneText[i].GetComponent<Text>().text = ownItem[i].ToString();

		}

	}
}
