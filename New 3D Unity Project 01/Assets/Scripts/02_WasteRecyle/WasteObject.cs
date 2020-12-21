using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WasteObject : MonoBehaviour,IPointerDownHandler,IPointerExitHandler,IPointerUpHandler {
    public int type;
    private bool isHold;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isHold == true)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        isHold = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        isHold = false;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        isHold = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isHold = false;
    }
}
