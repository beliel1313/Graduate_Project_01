using UnityEngine;
using UnityEngine.UI;

public class For2ndExh : MonoBehaviour {
    // This script was coded ONLY for 108-2 final test!
	public Image noticeMark;
	public GameObject giveMoneyMsg;
	public GameObject msgPanel;
	public static bool isMoneyGived = false;

	void Start() 
	{
		if (isMoneyGived == true) noticeMark.gameObject.SetActive(false);
	}

	public void GetMoney() 
	{
		if (isMoneyGived == false) 
		{
			GameManager.moneyCount += 300;
			msgPanel.SetActive(true);
			giveMoneyMsg.SetActive(true);
			noticeMark.gameObject.SetActive(false);
			isMoneyGived = true;
		}
	}

}
