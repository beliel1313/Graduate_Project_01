using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _03_3_PLAY : MonoBehaviour {
	public StageProcess stageProcess;
	[Header("StageSet")]
	public GameObject[] wasteOnStage;
	public RectTransform objectArea;
	[Header("Player")]
	public GameObject player;
	public int gotMoney;
	[Header("UI")]
	public GameObject msgPanel; // 顯示訊息的 UI.Panel
	public GameObject successPanel;  // 通關的 UI.Panel
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		gotMoney = 0;

		for (int i = 0; i < 10; i++) 
		{
			float groundX = objectArea.transform.position.x +
				Random.Range(objectArea.rect.xMin, objectArea.rect.xMax);
			float groundY = objectArea.transform.position.y +
				Random.Range(objectArea.rect.yMin, objectArea.rect.yMax);
			int r = Random.Range(0, 5);
			Instantiate(wasteOnStage[r], 
				new Vector3(groundX, groundY,objectArea.transform.position.z), 
				Quaternion.identity, objectArea);
		}

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void StageFinish()
	{
		player.GetComponent<PCCtrl>().enabled = false;
		msgPanel.SetActive(true);
		successPanel.SetActive(true);
		GameManager.moneyCount += gotMoney;
		stageProcess.worldIsOpen[1] = true;
	}
}
