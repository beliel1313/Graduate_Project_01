using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuy : MonoBehaviour {
    [Header("Master")]
    public Transform cartBoard;

    [Header("GUI")]
    public Text textBill;
    private int totalBill;

	// Use this for initialization
	void Start () {
        totalBill = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (textBill != null) textBill.text = "合計 " + totalBill;

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        totalBill += collision.GetComponent<ItemMaster>().price;
        collision.tag = "InCart";

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        totalBill -= collision.GetComponent<ItemMaster>().price;
        collision.tag = "Untagged";

    }

    public void Buying()
    {
        while (cartBoard.childCount > 0) 
        {
            Debug.Log("Buy " + GameObject.FindGameObjectWithTag("InCart").name);
            Destroy(GameObject.FindGameObjectWithTag("InCart"));

        }

    }
}
