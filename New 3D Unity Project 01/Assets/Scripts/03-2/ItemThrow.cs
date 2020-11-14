using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemThrow : MonoBehaviour,IPointerClickHandler {
	public GameObject flyingObj;
	public GameObject throwThis;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}    
	public void OnPointerClick(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

}
