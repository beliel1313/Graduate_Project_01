using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteCane : MonoBehaviour {
    public int TypeNum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<WasteObject>() == true)
        {
            if (collision.gameObject.GetComponent<WasteObject>().type == TypeNum)
            {
                Destroy(collision.gameObject);
            }
            else if(collision.gameObject.GetComponent<WasteObject>().type != TypeNum)
            {
                print("WRONG!!");
            }
        }
    }
}
