﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {
	private bool isStart;
	public float tgtTension = 50;
	public Slider tensionBar;

	// Use this for initialization
	void Start () {
		tensionBar.minValue = 0;
		tensionBar.maxValue = 100;
		isStart = true;
		InvokeRepeating("TensionUp", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		tensionBar.value = tgtTension;

	}

	void TensionUp()
	{
		if (isStart == true && 0 < tensionBar.value && tensionBar.value < 100) tgtTension += 5;

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.GetComponent<ItemParameter>() != null) 
		{
			tgtTension += other.gameObject.GetComponent<ItemParameter>().ATK;
			//if (tgtTension < 0) print("CLEAR!!");
		}

		other.gameObject.SetActive(false);
	}
}
