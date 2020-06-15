using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackBag : MonoBehaviour {
	public Text bagMsg;
	public GameObject itemManage;
	private int itemSum;

	// Use this for initialization
	void Start () {
		itemSum = itemManage.GetComponent<ItemManager>().items.Length;
		bagMsg.text = "";

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
