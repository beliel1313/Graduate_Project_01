﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerParameter : MonoBehaviour {
    [Header("Master")]
    public GameObject GM;
    public GameObject IM;
    [Header("HP")]
    public static float hp = 100;
    public Slider hpBar;
    [Header("ScoreText")]
    public Text coinText;
    private int coinCount = 0;
    public Text cloverText;
    private int cloverCount = 0;
    public GameObject animalIcon;
    private bool clearPermiss = false;

    public AudioSource coinSfx, cloverSfx, animalSfx;
    public GameObject msgPanel;

    [Header("Clear")]
    public GameObject clearPanel;

	// Use this for initialization
	void Start () {
        // 賦予角色生命值與血條
        hpBar.maxValue = hp;
        hpBar.value = hpBar.maxValue;

	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(hp);
        // 將生命值更新給血條
        hpBar.value = hp;
        // 將物件計數更新給文字
        //coinText.text = " X " + GameManager.moneyCount;
        cloverText.text = " X " + cloverCount;
        // 應急: 幸運草全收集通關
        if (cloverCount == 3) {
            //clearPermiss = true;
        }

        // HP歸0重置
        if (hp <= 0) Restart();
	}

    // 角色碰撞處理
    private void OnTriggerEnter2D(Collider2D collision) {
        // 陷阱碰撞傷害
        if (collision.tag == "Trap") {
            hp -= collision.GetComponent<TrapDamage>().oneTime;
            hpBar.value = hp;
            print("Touch Trap");
        }
        // 錢幣碰撞取得
        if (collision.tag == "Coin") {
            collision.gameObject.SetActive(false);
            GameManager.moneyCount += 10;
            coinSfx.Play();
        }
        // 幸運草碰撞取得
        if (collision.tag == "Clover") {
            collision.gameObject.SetActive(false);
            cloverCount += 1;
            cloverSfx.Play();
        }
        // 動物碰撞取得
        if (collision.tag == "Animal") {
            //collision.gameObject.SetActive(false);
            //animalIcon.SetActive(true);
            //animalSfx.Play();
            //clearPermiss = true;
        }
        // 動物碰撞載入挑戰關
        if (collision.tag == "Animal")
        {
            msgPanel.SetActive(true);
            GM.GetComponent<GameManager>().GamePause();
            //GM.GetComponent<SceneLoader>().Play("D2_ChallengeDebug");
        }
        // 旗幟碰撞通關
        if (collision.tag == "Finish" && clearPermiss == true) {
            //Debug.Log("Clear");
            //StageClear();
        }
        // 道具碰撞取得
        if (collision.GetComponent<ItemMaster>() != null) 
        {
            IM.GetComponent<ItemManager>().ownItem[collision.GetComponent<ItemMaster>().itemNumber] += 1;
            collision.gameObject.SetActive(false);
            cloverSfx.Play();
        }

    }
    // 角色滯留傷害處理
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Trap") {
            hp -= collision.GetComponent<TrapDamage>().overTime;
            hpBar.value = hp;
            print("Touch Trap");
        }
    }
    // 通關處理
    private void StageClear() {
        clearPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    // 關卡重置處理
    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

}
