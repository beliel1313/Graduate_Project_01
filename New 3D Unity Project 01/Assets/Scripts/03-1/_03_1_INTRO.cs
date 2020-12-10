using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _03_1_INTRO : MonoBehaviour {
    public GameObject introMsg, introTxt;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("player in");
            InvokeRepeating("FadeIn", 0f, 0.025f);
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());

        }
    }

    void FadeIn()
    {
        if (introMsg.GetComponent<Image>().color.a <= 0.5f) 
        {
            introMsg.GetComponent<Image>().color += new Color(0, 0, 0, 0.1f);
        }
        if (introTxt.GetComponent<Text>().color.a <= 1f)
        {
            introTxt.GetComponent<Text>().color += new Color(0, 0, 0, 0.5f);
        }
        if (introMsg.GetComponent<Image>().color.a >= 0.5f && introTxt.GetComponent<Text>().color.a >= 1f) 
        {
            CancelInvoke("FadeIn");
            InvokeRepeating("FadeOut", 1f, 0.025f);
        }
    }

    void FadeOut()
    {
        if (introMsg.GetComponent<Image>().color.a > 0f)
        {
            introMsg.GetComponent<Image>().color -= new Color(0, 0, 0, 0.1f);
        }
        if (introTxt.GetComponent<Text>().color.a > 0f)
        {
            introTxt.GetComponent<Text>().color -= new Color(0, 0, 0, 0.5f);
        }
        if (introMsg.GetComponent<Image>().color.a <= 0f && introTxt.GetComponent<Text>().color.a <= 0f) 
        {
            CancelInvoke("FadeOut");
        }

    }
}
