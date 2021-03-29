using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _02_4_WasteMove : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {
    public float xSpeed;
    private bool isHold;

    // Use this for initialization
    void Start () {
        Invoke("ObjectMove", 0f);
    }
	
	// Update is called once per frame
	void Update () {

        if (isHold == true)
        {
            //xSpeed = 0;
            CancelInvoke("ObjectMove");
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else
        {
            //transform.Translate(transform.right * xSpeed);
            Invoke("ObjectMove", 0f);

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHold = true;
        //CancelInvoke("ObjectMove");
        print("hold" + gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHold = false;
        //Invoke("ObjectMove", 0f);

    }

    public void ObjectMove()
    {
        transform.Translate(transform.right * xSpeed);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

}
