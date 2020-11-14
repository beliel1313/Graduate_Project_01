using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _03_2_PLAY : MonoBehaviour {
	[Header("GamePlay")]
	public StageProcess stageProcess;
	public GameObject flyingObj;
	public GameObject[] throwItem;
	public Target target;
	private float tgtTension;
	private int count = 4;
	[Header("UI")]
	// public GameObject blockPanel;   // 阻擋操作的 UI.Panel
	public GameObject msgPanel; // 顯示訊息的 UI.Panel
	public Text countText;  //開始前倒數 UI.Text
	public GameObject failPanel, successPanel;  // 失敗與通關的 UI.Panel

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}

	// Update is called once per frame
	void Update () {
		// tgtTension = target.tgtTension;

		if (target.tgtTension <= 0)
		{
			msgPanel.SetActive(true);  // 啟動 msgPanel
			failPanel.SetActive(true);
		}
		if (target.tgtTension >= 100)
		{
			msgPanel.SetActive(true);  // 啟動 msgPanel
			successPanel.SetActive(true);
			stageProcess.stageIsOpen[2] = true;
		}

	}

	// 啟動倒數計時
	public void Play()
	{
		Time.timeScale = 1;
		InvokeRepeating("StartCount", 0f, 1f);    // 0s後, 每1s重複執行 StartCount()
	}
	// 倒數計時後執行 TensionStart()
	public void StartCount()
	{
		countText.text = (count -= 1).ToString();
		if (count == 0)
		{
			InvokeRepeating("TensionStart", 1f, 1f);    // 0.2s後, 每0.5s重複執行 StageStart()
			msgPanel.SetActive(false);  // 關閉 msgPanel
			CancelInvoke("StartCount"); // 中止執行此方法
		}
	}
	public void TensionStart() 
	{
		target.TensionChange();
	}
	public void Throw(int i)
	{
		Instantiate(throwItem[i], flyingObj.transform, false);
		flyingObj.SetActive(true);
	}

}
