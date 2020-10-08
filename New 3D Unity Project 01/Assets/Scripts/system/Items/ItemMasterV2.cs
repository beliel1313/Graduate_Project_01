using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMasterV2 : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler {
    // 使道具圖像可被游標點擊; 游標移入時顯示訊息, 並於游標移出時消失
    // 由道具自體管理之參數設於此語法
    // 編號; 名稱; 價格; 回復值; 
    public int itemNum;
    public string itemName;
    public int itemPrice;
    public int itemHeal;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
