using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInShop : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    // 使道具圖像可被游標點擊; 游標移入時顯示訊息, 並於游標移出時消失
    // 僅在有商店之場景, 對商店中道具添加此腳本
    // 點擊商品架的道具, 複製道具進入購物車
    // 點擊購物車的複製道具, 使複製道具消滅
    // 需要商店的元件

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
