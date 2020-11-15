using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCTouch : MonoBehaviour {
	public int gotPrice;
	public int gotWaste;
	public _03_3_PLAY stageManager;
	public Text wasteCount;

	// Use this for initialization
	void Start () {
		gotPrice = 0;
		gotWaste = 0;
	}
	
	// Update is called once per frame
	void Update () {
		wasteCount.text = gotWaste.ToString();
	}

	void OnTriggerStay2D(Collider2D collision) 
	{
		if (collision.GetComponent<Waste>() == true && collision.GetComponent<Waste>().enabled == true) 
		{
			Destroy(collision.gameObject);
			gotPrice += collision.GetComponent<Waste>().price;
			gotWaste += 1;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Finish")
		{
			stageManager.gotMoney += gotPrice;
			stageManager.StageFinish();
		}
	}

}
