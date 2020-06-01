using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    //goods and shop slots
    public GameObject[] slotFood;
    public GameObject[] slotTool;
    public GameObject[] slotGear;
    public GameObject[] foods;
    public GameObject[] tools;
    public GameObject[] gears;
    //shop messages
    public GameObject noStockMsg;
    //public GameObject msgPanel;
    //private Text msgText;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < foods.Length; i++)
        {
            Instantiate(foods[i].gameObject, slotFood[i].transform, false);
            Debug.Log(foods[i].name + " " + foods[i].transform.position);

        }

        for (int i = 0; i < tools.Length; i++)
        {
            Instantiate(tools[i].gameObject, slotTool[i].transform, false);
            Debug.Log(tools[i].name + " " + tools[i].transform.position);

        }

        for (int i = 0; i < gears.Length; i++)
        {
            Instantiate(gears[i].gameObject, slotGear[i].transform, false);
            Debug.Log(gears[i].name + " " + gears[i].transform.position);

        }

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
