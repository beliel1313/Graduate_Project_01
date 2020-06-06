using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
	public GameObject[] items;
	public int[] ownItem;

	// Use this for initialization
	void Start() {
		ownItem = new int[items.Length];
		for (int i = 0; i < items.Length; i++) 
		{
			items[i].GetComponent<ItemMaster>().itemNumber = i;
			items[i].GetComponent<ItemMaster>().owned = 0;
			ownItem[i] = 0;

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
