using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuy : MonoBehaviour {
    [Header("Master")]
    public Transform cartBoard;
    public GameObject itemsManager;

    [Header("GUI")]
    public Text textBill;
    private int totalBill;
    public Text moneyText;
    public int moneyC;
    public Button purchaseBtn;

	// Use this for initialization
	void Start () {
        moneyC = GameManager.moneyCount;
        totalBill = 0;
        moneyText.text = moneyC.ToString();
        purchaseBtn.interactable = true;

    }

    // Update is called once per frame
    void Update () {
        moneyC = GameManager.moneyCount;
        if (textBill != null) textBill.text = "合計 " + totalBill + " 元";
        if (totalBill > 0 && moneyC - totalBill >= 0)
        {
            moneyText.color = Color.yellow;
            moneyText.text = moneyC + " ( -" + totalBill + ")";
            purchaseBtn.interactable = true;

        }
        else if (totalBill > 0 && moneyC - totalBill < 0) 
        {
            moneyText.color = Color.red;
            moneyText.text = moneyC + " ( -" + totalBill + ")";
            //purchaseBtn.enabled = false;
            purchaseBtn.interactable = false;
        }
        else if (totalBill == 0)
        {
            moneyText.color = Color.white;
            moneyText.text = moneyC.ToString();
            purchaseBtn.interactable = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        totalBill += collision.GetComponent<ItemMaster>().price;
        //collision.tag = "InCart";

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        totalBill -= collision.GetComponent<ItemMaster>().price;
        //collision.tag = "Untagged";

    }

    public void Buying()
    {
        for (int i = 0; i < cartBoard.childCount; i++) 
        {
            itemsManager.GetComponent<ItemManager>()
                .ownItem[cartBoard.GetChild(i).gameObject.GetComponent<ItemMaster>().itemNumber] += 1;
            //ItemManager.ownItem
            //    [cartBoard.GetChild(i).gameObject.GetComponent<ItemMaster>().itemNumber] += 1;
            //ItemMaster.staOwn += cartBoard.GetChild(i).gameObject.GetComponent<ItemMaster>().owned;

        }

        moneyC -= totalBill;
        GameManager.moneyCount = moneyC;
        CartClear();

    }

    public void CartClear()
    {
        for (int i = 0; i < cartBoard.childCount; i++) Destroy(cartBoard.GetChild(i).gameObject);

    }

}
