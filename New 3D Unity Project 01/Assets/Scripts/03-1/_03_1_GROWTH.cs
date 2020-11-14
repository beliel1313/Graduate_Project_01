using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _03_1_GROWTH : MonoBehaviour,IPointerClickHandler {
    private Animation growthAnim;
    public int num; // 草叢編號
    public _03_1_PLAY stagePlay; //取得關卡1-1控制器

    // Use this for initialization
    void Start () {
        print(gameObject.name + " " + num);

        growthAnim = gameObject.GetComponent<Animation>();  // 取得草叢動畫
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        growthAnim.Play();  // 點擊時播放動畫
        stagePlay.clickTime += 1;   //點擊時控制器的 clickTime += 1

        if (stagePlay.answer == num)    // 點擊時, 草叢編號與正解一致時進行下列程式
        {
            stagePlay.isFind = true;
            stagePlay.FindAnimal(); // 執行控制器的 FindAnimal()
        }

        if (stagePlay.clickTime >= 3 && stagePlay.isFind == false) 
        {
            stagePlay.NotFound();
        }
    }

}
