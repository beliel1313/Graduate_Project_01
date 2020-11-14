using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _03_1_PLAY : MonoBehaviour {
	[Header("GamePlay")]
	public StageProcess stageProcess;
	public Transform[] growth;	// 草叢
	public GameObject animal;   //動物
	private int count1 = 4;  // StartCount() 執行次數
	private int count2 = 0;  // StageStart() 執行次數
	public int answer = 0; // 正解編號
	public int clickTime = 0;   //點擊草叢次數
	public bool isFind;	// 是否找到
	[Header("UI")]
	public GameObject blockPanel;   // 阻擋操作的 UI.Panel
	public GameObject msgPanel; // 顯示訊息的 UI.Panel
	public Text countText;  //開始前倒數 UI.Text
	public GameObject failPanel, successPanel;  // 失敗與通關的 UI.Panel

	// Use this for initialization
	void Start () {
		for (int i = 0; i< 8; i++) 
		{
			// 給草叢依序加上編號
			growth[i].gameObject.GetComponent<_03_1_GROWTH>().num = i;
		}
	}

	// Update is called once per frame
	void Update () {

	}
	// 啟動倒數計時
	public void Play()
	{
		InvokeRepeating("StartCount", 0f, 1f);    // 0s後, 每1s重複執行 StartCount()
	}
	// 倒數計時後執行 StageReady()
	public void StartCount() 
	{
		countText.text = (count1 -= 1).ToString();
		if (count1 == 0) 
		{
			InvokeRepeating("StageReady", 0.2f, 0.5f);    // 0.2s後, 每0.5s重複執行 StageStart()
			msgPanel.SetActive(false);  // 關閉 msgPanel
			CancelInvoke("StartCount"); // 中止執行此方法
		}
	}
	// 關卡開始時隨機決定正解編號
	public void StageReady()
	{
		int r = Random.Range(0, 8);
		if (count2 < 10)   // 執行次數 <=10 則執行以下程式 
		{
			growth[r].gameObject.GetComponent<Animation>().Play();  //隨機播放草叢動畫
			count2 += 1;    //每次執行次數 +1
		}
		if (count2 >= 10)	// 執行次數 >10 則執行以下程式
		{
			answer = r; // 使正解為最終亂數
			blockPanel.SetActive(false);    // 關閉 blockPanel
			CancelInvoke("StageReady"); // 中止執行此方法
		}
		print("answer " + answer);
	}
	// 正解 FindAnimal() -> Success()
	public void FindAnimal() 
	{
		Instantiate(animal, growth[answer], false);
		blockPanel.SetActive(true); // 啟動 blockPanel
		Invoke("Success", 2f);
	}
	private void Success() 
	{
		msgPanel.SetActive(true);  // 啟動 msgPanel
		successPanel.SetActive(true);   // 啟動 successPanel
		stageProcess.stageIsOpen[1] = true;
	}
	// 失敗 NotFound() -> Failed()
	public void NotFound()
	{
		blockPanel.SetActive(true); // 啟動 blockPanel
		Invoke("Failed", 2f);
	}
	private void Failed() 
	{
		msgPanel.SetActive(true);  // 啟動 msgPanel
		failPanel.SetActive(true);

	}
}
