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
        InvokeRepeating("Timer", 0f, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (wasteKilled == GenPoint.Length) 
        {
            Invoke("Success", 0.8f);
        }

	}

    public void GenWastes()
    {
        for (int i = 0; i < GenPoint.Length; i++)
        {
            int r = Random.Range(0, waste.Length);
            Instantiate(waste[r], GenPoint[i]);
        }

    }

    public void WrongMsg() 
    {
        topMsg.text = "丟錯垃圾桶 !";
        Invoke("EraseMsg", 0.6f);
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
        CancelInvoke("Timer");
        sysPnl.SetActive(true);
        successPnl.SetActive(true);
        timeCount.text = "花費時間 " + useTime.ToString("00.0") + " 秒";
    }
}
