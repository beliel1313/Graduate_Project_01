using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (hp <= 0) Restart();
	}

    // 角色碰撞傷害處理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trap")
        {
            hp -= 3;
            hpBar.value = hp;
            print("Touch Trap");
            Debug.Log(hp);
        }
    }
    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

}
