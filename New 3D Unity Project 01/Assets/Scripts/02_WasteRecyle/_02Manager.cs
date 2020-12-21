using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _02Manager : MonoBehaviour {
    public GameManager gameManager;
    public GameObject[] waste;
    public RectTransform genArea;

    public Text topMsg;

	// Use this for initialization
	void Start () {
        gameManager.GamePause();

        GenWastes();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenWastes()
    {
        for (int i = 0; i < 6; i++)
        {
            // genArea.transform.position.x
            // genArea.transform.position.y

            float groundX = genArea.transform.position.x +
                Random.Range(genArea.rect.xMin, genArea.rect.xMax);
            float groundY = genArea.transform.position.y +
                Random.Range(genArea.rect.yMin, genArea.rect.yMax);
            int r = Random.Range(0, waste.Length-1);
            Instantiate(waste[r],
                new Vector3(groundX, groundY, genArea.transform.position.z),
                Quaternion.identity, genArea);
        }

    }
}
