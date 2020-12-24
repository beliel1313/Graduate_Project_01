using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _03_1_IntroManager : MonoBehaviour {
	public PCCtrl pc;
	public Image startPnl;
	public Text textInPnl;

	// Use this for initialization
	void Start () {
		InvokeRepeating("StageIntro", 2f, 0.05f);
		Destroy(startPnl.gameObject, 3f);
		pc.enabled = false;
		Invoke("ActivePC", 3f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StageIntro() 
	{
		startPnl.color -= new Color(0, 0, 0, 0.05f);
		textInPnl.color -= new Color(0, 0, 0, 0.05f);
	}
	void ActivePC() 
	{
		pc.enabled = true;
	}
}
