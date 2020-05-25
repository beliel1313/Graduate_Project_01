using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuy : MonoBehaviour {
    [Header("Master")]
    public RectTransform cartBoard;

    [Header("Shop Food")]
    public GameObject[] foods;

    [Header("Shop Tool")]
    public GameObject[] tools;

    [Header("Shop Gear")]
    public GameObject[] gears;

    [Header("GUI")]
    public Text textBill;
    private int totalBill;

	// Use this for initialization
	void Start () {
        totalBill = 0;

	}
	
	// Update is called once per frame
	void Update () {
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

    public void PutInCart()
    {

    }

    public void Buying()
    {
        Debug.Log("Buy " + GameObject.FindGameObjectWithTag("InCart").name);
        Destroy(GameObject.FindGameObjectWithTag("InCart"));
        
    }
}
