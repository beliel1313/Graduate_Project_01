using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour {

    GameManager gm;
    Canvas canva;
    public Text textBox;
    public Text ticket;
    [Header("Buy Ticket UI")] //一次購買多個的彈窗
    public Text num;
    public Button minus;
    public Button plus;
    int buyNum;
    private int price;
    [Header("Panel")]
    public GameObject noTicket; //沒有票，要否去買的彈窗
    public GameObject drawOne;
    public GameObject drawTen;
    [Header("Prize")] //獎品
    public GameObject cat;
    public GameObject heart;
    public GameObject clock;
    public GameObject red;
    public GameObject blue;
    public GameObject yellow;
    GameObject[] tenPrize; //抽十連

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        canva = FindObjectOfType<Canvas>();
    }

    void Start()
    {
        buyNum = 1;
        price = 1000; //票價1000
    }

    void Update () {
        ticket.text = gm.ticket.ToString();
        if (buyNum <= 1) minus.interactable = false;
        else minus.interactable = true;
        if (gm.coins <= buyNum * price) plus.interactable = false; //大於金錢數量，按鈕不能點
        else plus.interactable = true;
    }

    public void BuyTicket()
    {
        if (buyNum == 0)
        {
            Text tempTextBox = Instantiate(textBox, new Vector3(0, 0, 0), transform.rotation) as Text;
            tempTextBox.transform.SetParent(canva.transform, false);
            tempTextBox.fontSize = 50;
            tempTextBox.text = "Please enter a number";
            Destroy(tempTextBox, 2f);
        }
        else if(gm.coins < buyNum * price)
        {
            NoCoinText();
        }
        else
        {
            gm.ticket += buyNum;
            gm.coins -= buyNum * price;
            buyNum = 1;
        }
    }

    public void DrawOne()
    {
        if (gm.ticket < 1) noTicket.gameObject.SetActive(true);
        else
        {
            gm.ticket--;
            RandomNum();
            drawOne.gameObject.SetActive(true);
        }
    }

    public void DrawTen()
    {
        if (gm.ticket < 10) noTicket.gameObject.SetActive(true);
        else
        {
            int x = 80; int y = 220; //獎品位置直接生成，可能有bug
            gm.ticket -= 10;
            for(int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    RandomNum(x, y);
                    x += 100;
                }
                x = 80;
                y -= 100;
            }
            drawTen.gameObject.SetActive(true);
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

    void NoCoinText()
    {
        Text tempTextBox = Instantiate(textBox, new Vector3(0, 0, 0), transform.rotation) as Text;
        tempTextBox.transform.SetParent(canva.transform, false);
        tempTextBox.fontSize = 50;
        tempTextBox.text = "You haven't enough coin";
        Destroy(tempTextBox, 2f);
    }

    void RandomNum()
    {
        int num = Random.Range(0, 20);
        Debug.Log(num);
        if (num >= 19)
        {
            ImageInstant(cat);
            gm.haveCat = true;
        }
        else if (num > 16){
            ImageInstant(heart);
            gm.heart++;
        }else if (num > 14)
        {
            ImageInstant(clock);
            gm.clock++;
        }else if (num > 12)
        {
            ImageInstant(blue);
            gm.blue++;
        }else if (num > 7)
        {
            ImageInstant(yellow);
            gm.yellow++;
        }
        else
        {
            ImageInstant(red);
            gm.red++;
        }
    }

    void RandomNum(int x, int y)
    {
        int num = Random.Range(0, 20);
        Debug.Log(num);
        if (num >= 19)
        {
            ImageInstant(cat, x, y);
            gm.haveCat = true;
        }
        else if (num > 16)
        {
            ImageInstant(heart, x, y);
            gm.heart++;
        }
        else if (num > 14)
        {
            ImageInstant(clock, x, y);
            gm.clock++;
        }
        else if (num > 12)
        {
            ImageInstant(blue, x, y);
            gm.blue++;
        }
        else if (num > 7)
        {
            ImageInstant(yellow, x, y);
            gm.yellow++;
        }
        else
        {
            ImageInstant(red, x, y);
            gm.red++;
        }
    }

    public void ClickEnter()
    {
        tenPrize = GameObject.FindGameObjectsWithTag("Prize");
        for (int i = 0; i < tenPrize.Length; i++)
        {
            Destroy(tenPrize[i]);
        }
    }

    void ImageInstant(GameObject perfab) //獎品位置直接生成，可能有bug
    {
        GameObject instant = Instantiate(perfab, new Vector3(290, 180, 0), Quaternion.identity);
        instant.transform.parent = GameObject.Find("Canvas").gameObject.transform;
        instant.transform.localScale = GameObject.Find("Canvas").gameObject.transform.GetChild(0).transform.localScale;
    }

    void ImageInstant(GameObject perfab, int x, int y)
    {
        GameObject instant = Instantiate(perfab, new Vector3(x, y, 0), Quaternion.identity);
        instant.transform.parent = GameObject.Find("Canvas").gameObject.transform;
        instant.transform.localScale = GameObject.Find("Canvas").gameObject.transform.GetChild(0).transform.localScale;
        instant.transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }
}
