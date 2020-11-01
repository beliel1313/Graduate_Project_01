using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (For2ndExh.isMoneyGived == true)
        {
            gameObject.SetActive(false);
        }
	}
}
