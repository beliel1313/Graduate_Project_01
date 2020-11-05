using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _03_1_GROWTH : MonoBehaviour,IPointerClickHandler {

    // Use this for initialization
    void Start () {
        print("_03_1_GROWTH is working.");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        print(transform.name);
    }

}
