using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragnDrop : MonoBehaviour {

    float OffsetX;
    float OffsetY;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void BeginDrag()
    {
        OffsetX = transform.position.x - Input.mousePosition.x; ;
        OffsetY = transform.position.y - Input.mousePosition.y; ;
    }

    public void OnDrag()
    {
        transform.position = new Vector3(Input.mousePosition.x + OffsetX, Input.mousePosition.y + OffsetY);

    }
}
