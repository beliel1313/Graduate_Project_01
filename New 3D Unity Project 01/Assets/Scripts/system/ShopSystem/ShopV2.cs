using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopV2 : MonoBehaviour {
	public ItemManagerV2 ItemManager;

	public GameObject[] slotFood;	// 食物類商品櫃
	public GameObject[] slotTool;   // 工具類商品櫃
	public GameObject[] slotGear;   // 裝備類商品櫃

	// Use this for initialization
	void Start () {
		// 從ItemManager複製道具到商店
		Instantiate(ItemManager.foods[0], slotFood[0].transform, false);

		// 對商店內道具添加 "ItemInShop" 腳本

	}

	// Update is called once per frame
	void Update () {
		
	}
}
