using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WasteObject : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {
    public int type, evTrigger;
    private bool isHold;
    private Vector2 startPos;
    public _02Manager manager;
    public string wasteMsg;

    // Use this for initialization
    void Start () {
        startPos = gameObject.GetComponentInParent<Transform>().position;
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
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        isHold = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish") 
        {
            isHold = false;
            transform.position = new Vector2(startPos.x, startPos.y);
            manager.Warning();
        }
        if (collision.GetComponent<WasteCane>() == true) 
        {
            if (collision.GetComponent<WasteCane>().TypeNum == type)
            {
                manager.CorrectMsg();
            }
            if (collision.GetComponent<WasteCane>().TypeNum != type &&
                collision.GetComponent<WasteCane>().TypeNum != evTrigger)
            {
                manager.WrongMsg();
            }
            if (collision.GetComponent<WasteCane>().TypeNum == evTrigger)
            {
                manager.topMsg.text = wasteMsg;
            }

        }

    }
}
