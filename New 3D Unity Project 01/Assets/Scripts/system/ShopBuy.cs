using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuy : MonoBehaviour {

    public Text textBill;
    private int totalBill;

	// Use this for initialization
	void Start ()
    {
        totalBill = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        textBill.text = "合計 " + totalBill.ToString();

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        totalBill += collision.GetComponent<ItemFood>().price;
        collision.tag = "InCart";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        totalBill -= collision.GetComponent<ItemFood>().price;
        collision.tag = "Untagged";
    }

    public void Buying()
    {
        Debug.Log("Buy " + GameObject.FindGameObjectWithTag("InCart").name);
        Destroy(GameObject.FindGameObjectWithTag("InCart"));
    }
}
