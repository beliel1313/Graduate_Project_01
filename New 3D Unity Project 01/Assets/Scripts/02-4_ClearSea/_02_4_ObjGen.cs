using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _02_4_ObjGen : MonoBehaviour {
    public Transform[] genPoint;
    public GameObject[] waste;
    public float genRate;
    public float genTimeCount;
    public float xSpeed;

	// Use this for initialization
	void Start () {
        InvokeRepeating("GenRate", 0.1f, 0.1f);
        genRate = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenRate()
    {
        genTimeCount += 0.1f;
        if (genTimeCount >= genRate)
        {
            WasteGen();
            genTimeCount = 0;
        }
    }
    public void WasteGen()
    {
        GameObject wasteClone;

        int rG = Random.Range(0, genPoint.Length);
        int rW = Random.Range(0, waste.Length);

        xSpeed = Random.Range(1.0f, 5.0f);
        wasteClone = Instantiate(waste[rW], genPoint[rG]);
        wasteClone.GetComponent<_02_4_WasteMove>().xSpeed = xSpeed;

    }
}
