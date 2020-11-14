﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScrCtrl : MonoBehaviour {
	[Header("MainScreen")]
	static public bool back2Map;
	public GameObject home, map;
	public GameObject btn2map, btn2home;
	[Header("StageAccess")]
	public StageProcess stageProcess;
	public Button[] btn2Stage;
	public Button[] btn2World;

	void Awake()
	{
		// 離開關卡時回到地圖選關畫面
		if (back2Map == true)
		{
			map.SetActive(true);
			home.SetActive(false);
			btn2map.SetActive(false);
			btn2home.SetActive(true);
		}
		else
		{
			map.SetActive(false);
			home.SetActive(true);
			btn2map.SetActive(true);
			btn2home.SetActive(false);

		}

		for (int i = 0; i < btn2Stage.Length; i++) 
		{
			if (stageProcess.stageIsOpen[i] == true) 
			{
				btn2Stage[i].interactable = true;
			}
		}
	}


	public void BackToMap() 
	{
		back2Map = !back2Map;
	}
}
