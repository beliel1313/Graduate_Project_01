using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _02Manager : MonoBehaviour {
    [Header("Play")]
    public GameManager gameManager;
    public WasteCane cane;
    public GameObject[] waste;
    public Transform[] GenPoint;
    public int wasteKilled;
    private float useTime;
    [Header("UI")]
    public Text topMsg, timeCount;
    public GameObject sysPnl, successPnl;

	// Use this for initialization
	void Start () {
        gameManager.GamePause();
        GenWastes();
        for (int i = 0; i < waste.Length; i++) 
        {
            // waste[i].GetComponent<WasteObject>().manager = gameObject.GetComponent<_02Manager>();
        }
        InvokeRepeating("Timer", 0f, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (wasteKilled == GenPoint.Length) 
        {
            CancelInvoke("Timer");
            Invoke("Success", 0.8f);
        }

	}

    public void GenWastes()
    {
        GameObject wasteClone;
        for (int i = 0; i < GenPoint.Length; i++)
        {
            int r = Random.Range(0, waste.Length);
            wasteClone = Instantiate(waste[r], GenPoint[i]);
            wasteClone.GetComponent<WasteObject>().manager = gameObject.GetComponent<_02Manager>();
        }

    }

    public void CorrectMsg() 
    {
        topMsg.text = "正確 !";
        Invoke("EraseMsg", 1f);

    }
    public void WrongMsg() 
    {
        topMsg.text = "丟錯垃圾桶 !";
        Invoke("EraseMsg", 1f);
    }
    public void Warning() 
    {
        topMsg.text = "請不要亂丟垃圾 !";
        Invoke("EraseMsg", 1f);

    }
    private void EraseMsg() 
    {
        topMsg.text = "";
    }

    private void Timer() 
    {
        useTime += 0.1f;
    }
    public void Success() 
    {
        sysPnl.SetActive(true);
        successPnl.SetActive(true);
        timeCount.text = "花費時間 " + useTime.ToString("00.0") + " 秒";
    }
}
