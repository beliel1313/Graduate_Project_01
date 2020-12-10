using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _03_1_INTRO2STAGE : MonoBehaviour {
    public SceneLoader loader;
    public PCCtrl pc;

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
            pc.enabled = false;
            pc.gameObject.GetComponent<Animator>().SetBool("isWalking", false);
            loader.Play("03-1B_ForestStage1");
        }

    }
}
