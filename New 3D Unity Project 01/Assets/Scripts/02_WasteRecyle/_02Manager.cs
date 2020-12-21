using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _02Manager : MonoBehaviour {
    public GameManager gameManager;
    public GameObject[] waste;
    public Transform[] GenPoint;

    public Text topMsg;

	// Use this for initialization
	void Start () {
        gameManager.GamePause();
        GenWastes();

	}
	
	// Update is called once per frame
	void Update () {
		
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
}
