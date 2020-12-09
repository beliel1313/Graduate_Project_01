using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorFinder : MonoBehaviour {
	private GameObject tgt;
	public string colorValue;

	// Use this for initialization
	void Start () {
		tgt = gameObject;
		colorValue = (tgt.GetComponent<Image>().color.r.ToString("0.00") + ", " +
			tgt.GetComponent<Image>().color.g.ToString("0.00") + ", " +
			tgt.GetComponent<Image>().color.b.ToString("0.00") + ", " +
			tgt.GetComponent<Image>().color.a.ToString("0.00"));


	}

	// Update is called once per frame
	void Update () {
		
	}
}
