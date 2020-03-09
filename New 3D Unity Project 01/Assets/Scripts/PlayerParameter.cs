using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerParameter : MonoBehaviour {

    [Header("HP")]
    public float hp;
    public Slider hpBar;

	// Use this for initialization
	void Start () {
        // 賦予角色生命值予血條
        hpBar.maxValue = hp;
        hpBar.value = hpBar.maxValue;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            hp -= 10;
            hpBar.value = hp;
            Debug.Log(hp);
        }
	}

    // 角色碰撞傷害處理
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
