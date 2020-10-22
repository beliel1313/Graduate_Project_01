using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public GameObject[] slotFood;   // 食物類插槽
    public GameObject[] slotTool;   // 工具類插槽
    public GameObject[] slotGear;   // 裝備類插槽
    public GameObject[] foods;   // 食物類
    public GameObject[] tools;   // 工具類
    public GameObject[] gears;   // 裝備類

    public Text shopMsg;   // 商店內訊息
    public GameObject noStockMsg;   // 無存貨訊息
    public GameObject itemManage;   // 道具管理
    private int itemSum;
    //public GameObject msgPanel;
    //private Text msgText;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < foods.Length; i++)
        {
            Instantiate(foods[i].gameObject, slotFood[i].transform, false);
            //Debug.Log(foods[i].name + " " + foods[i].transform.position);

        }

        for (int i = 0; i < tools.Length; i++)
        {
            Instantiate(tools[i].gameObject, slotTool[i].transform, false);
            //Debug.Log(tools[i].name + " " + tools[i].transform.position);

        }

        for (int i = 0; i < gears.Length; i++)
        {
            Instantiate(gears[i].gameObject, slotGear[i].transform, false);
            //Debug.Log(gears[i].name + " " + gears[i].transform.position);

        }

        itemSum = itemManage.GetComponent<ItemManager>().items.Length;

    }

    // Update is called once per frame
    void Update () {

	}

    public void StockCheck(string stockCheck)
    {
        switch (stockCheck) 
        {
            case "Food":
                if (foods.Length < 1 || slotFood[0].transform.childCount == 0) 
                    noStockMsg.SetActive(true);
                break;

            case "Tool":
                if (tools.Length < 1 || slotTool[0].transform.childCount == 0) 
                    noStockMsg.SetActive(true);
                break;

            case "Gear":
                if (gears.Length < 1 || slotGear[0].transform.childCount == 0) 
                    noStockMsg.SetActive(true);
                break;

        }
    }
    public void ShopMsg()
    {
        //GameObject clone;
        //clone = Instantiate(msgPanel, gameObject.transform, false);

    }

}
