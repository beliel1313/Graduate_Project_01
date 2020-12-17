using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    GameManager gm;
    Canvas canva;
    public Text textBox;
    [Header("Shop Item Text")] //道具數量的text
    public Text clock;
    public Text heart;
    public Text yellow;
    public Text ticket;
    [Header("Sell Item Text")] //道具數量的text
    public Text black;
    public Text red;
    public Text blue;
    public Text yellowi;
    private int color;
    [Header("Buy Ticket UI")] //一次購買多個的彈窗
    public Text num;
    public Button minus;
    public Button plus;
    private int price;
    int buyNum;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        canva = FindObjectOfType<Canvas>();
    }

    void Start()
    {
        buyNum = 1;
        price = 1000;
    }

    void Update()
    {
        clock.text = gm.clock.ToString();
        heart.text = gm.heart.ToString();
        red.text = gm.red.ToString();
        blue.text = gm.blue.ToString();
        yellow.text = gm.yellow.ToString();
        yellowi.text = gm.yellow.ToString();
        black.text = gm.black.ToString();
        ticket.text = gm.ticket.ToString();
        if (buyNum <= 1) minus.interactable = false;
        else minus.interactable = true;
        if (gm.coins <= buyNum * price) plus.interactable = false; //大於金錢數量，按鈕不能點
        else plus.interactable = true;
    }

    void InstantText() //沒有足夠金錢的提示，位置可能有bug
    {
        Text tempTextBox = Instantiate(textBox, new Vector3(0, 0, 0), transform.rotation) as Text;
        tempTextBox.transform.SetParent(canva.transform, false);
        tempTextBox.fontSize = 50;
        tempTextBox.text = "You haven't enough coin";
        Destroy(tempTextBox, 2f);
    }

    void NoSellText() ////沒有足夠道具的提示，位置可能有bug
    {
        Text tempTextBox = Instantiate(textBox, new Vector3(0, 0, 0), transform.rotation) as Text;
        tempTextBox.transform.SetParent(canva.transform, false);
        tempTextBox.fontSize = 50;
        tempTextBox.text = "You haven't enough item";
        Destroy(tempTextBox, 2f);
    }

    public void BuyItem(string item)
    {
        if (item == "clock")
        {
            if (gm.coins < 348)
            {
                InstantText();
            }
            else
            {
                gm.clock++;
                gm.coins -= 348;
            }
        }
        if (item == "heart")
        {
            if (gm.coins < 468)
            {
                InstantText();
            }
            else
            {
                gm.heart++;
                gm.coins -= 468;
            }
        }
        if (item == "yellow")
        {
            if (gm.coins < 298)
            {
                InstantText();
            }
            else
            {
                gm.yellow++;
                gm.coins -= 298;
            }
        }
    }

    public void SellBlack()
    {
        if (gm.black < 1)
        {
            NoSellText();
        }
        else
        {
            gm.black--;
            gm.coins += 888;
        }
    }
    public void SellColor(string c)
    {
        if (c == "red") color = gm.red;
        if (c == "blue") color = gm.blue;
        if (c == "yellow") color = gm.yellow;
        if (color < 1)
        {
            NoSellText();
        }
        else
        {
            color--;
            gm.coins++;
        }
    }

    public void BuyTicket()
    {
        if (gm.coins < buyNum * price)
        {
            InstantText();
        }
        else
        {
            gm.ticket += buyNum;
            gm.coins -= buyNum * price;
            buyNum = 1;
        }
    }

    public void PlusTicket()
    {
        buyNum++;
        num.GetComponentInChildren<Text>().text = buyNum.ToString();
    }

    public void MinusTicket()
    {
        buyNum--;
        num.GetComponentInChildren<Text>().text = buyNum.ToString();
    }
}
