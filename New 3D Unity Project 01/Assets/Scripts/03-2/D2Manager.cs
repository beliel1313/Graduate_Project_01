using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D2Manager : MonoBehaviour {
	public GameObject flyingObj;
	public GameObject[] throwItem;

	public GameObject target;
	private float tgtTension;

	public GameObject blockPanel;
	public GameObject clearPanel, failedPanel;
	public Text countText;  //開始前倒數 UI.Text

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;

	}

    // Update is called once per frame
    void Update () {
		tgtTension = target.GetComponent<Target>().tgtTension;

		if (tgtTension <= 0) 
		{
			failedPanel.SetActive(true);
		}
		if (tgtTension >= 100) 
		{
			clearPanel.SetActive(true);
		}

    }

    public void Begin() 
	{
		Time.timeScale = 1;
	}

	public void Throw(int i) 
	{
		Instantiate(throwItem[i], flyingObj.transform, false);
		flyingObj.SetActive(true);
	}
}
