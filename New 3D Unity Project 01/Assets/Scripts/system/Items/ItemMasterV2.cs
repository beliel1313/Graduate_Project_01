using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMasterV2 : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler {
    // 使道具圖像可被游標點擊; 游標移入時顯示訊息, 並於游標移出時消失
    // 由道具自體管理之參數宣告於下
    public int itemNum; // 編號
    public string itemName; // 名稱
    public int itemPrice; // 價格
    public int itemHeal; // 回復值
    public int own; // 持有數
    // 叫用腳本宣告於下
    ItemManagerV2 ItemManager;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 游標點擊時叫用其他腳本
    public void OnPointerClick(PointerEventData eventData)
    {

    }

    // 游標進入時叫用其他腳本
    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    // 游標離開時叫用其他腳本
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
