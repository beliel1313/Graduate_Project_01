using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScroll : MonoBehaviour {

    public Slider mapScroll;
    public GameObject map;

	// Use this for initialization
	void Start () {
        mapScroll.value = map.transform.position.y;

    }
	
	// Update is called once per frame
	void Update () {
        float mapY = map.transform.position.y;
        mapY = mapScroll.value;
    }
}
