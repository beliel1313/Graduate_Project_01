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
    public Text moneyText;
    public int moneyCount;
    public Button purchaseBtn;

	// Use this for initialization
	void Start () {
        totalBill = 0;
        moneyText.text = "持有金額: " + moneyCount;
        purchaseBtn.interactable = true;

    }

    // Update is called once per frame
    void Update () {
        if (textBill != null) textBill.text = "合計 " + totalBill;
        if (totalBill > 0 && moneyCount - totalBill > 0)
        {
            moneyText.color = Color.yellow;
            moneyText.text = "持有金額: " + moneyCount + " ( -" + totalBill + ")";
            purchaseBtn.interactable = true;

        }
        else if (totalBill > 0 && moneyCount - totalBill < 0) 
        {
            moneyText.color = Color.red;
            moneyText.text = "持有金額: " + moneyCount + " ( -" + totalBill + ")";
            //purchaseBtn.enabled = false;
            purchaseBtn.interactable = false;
        }
        else if (totalBill == 0)
        {
            moneyText.color = Color.white;
            moneyText.text = "持有金額: " + moneyCount;
            purchaseBtn.interactable = true;
        }

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
        moneyCount -= totalBill;

        while (cartBoard.childCount > 0) 
        {
            Debug.Log("Buy " + GameObject.FindGameObjectWithTag("InCart").name);
            Destroy(GameObject.FindGameObjectWithTag("InCart"));

        }

    }
}
