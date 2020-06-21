using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D2Manager : MonoBehaviour {
	public GameObject flyingObj;
	public GameObject ownItem;
	public GameObject[] throwItem;
	public Text[] itemQua;

	public GameObject target;
	private float tgtTension;

	public GameObject blockPanel;
	public GameObject clearPanel, failedPanel;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		itemQua[0].text = (ownItem.GetComponent<OwnItem>().ownItem[6]).ToString();
		itemQua[1].text = (ownItem.GetComponent<OwnItem>().ownItem[7]).ToString();
		itemQua[2].text = (ownItem.GetComponent<OwnItem>().ownItem[8]).ToString();

		tgtTension = target.GetComponent<Target>().tgtTension;
		if (tgtTension <= 0)
		{
			clearPanel.SetActive(true);

		}
		else if (tgtTension >= 100) 
		{
			failedPanel.SetActive(true);

		}


	}

	public void Begin() 
	{
		Time.timeScale = 1;
	}

	public void Throw(int i) 
	{
		if (ownItem.GetComponent<OwnItem>().ownItem[i + 6] > 0)
		{
			Instantiate(throwItem[i], flyingObj.transform, false);
			ownItem.GetComponent<OwnItem>().ownItem[i + 6] -= 1;
			flyingObj.SetActive(true);

		}
	}
}
