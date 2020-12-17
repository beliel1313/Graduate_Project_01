using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Synthesis : MonoBehaviour {

    GameManager gm;
    Canvas canva;
    public Text textBox;
    [Header("Item Text")]
    public Text red;
    public Text blue;
    public Text yellow;
    [Header("Merge Item")]
    public GameObject black;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        canva = FindObjectOfType<Canvas>();
    }

    void Update()
    {
        red.text = gm.red.ToString() + "/4";
        blue.text = gm.blue.ToString() + "/4";
        yellow.text = gm.yellow.ToString() + "/4";
    }

    public void MixUpButton()
    {
        if (gm.red >= 4 && gm.blue >= 4 && gm.yellow >= 4)
        {
            black.SetActive(true);
            gm.black++;
            gm.red -= 4; gm.blue -= 4; gm.yellow -= 4;
        }
        else
        {
            NoMaterialText();
            black.SetActive(false);
        }
    }

    void NoMaterialText() //沒有足夠合成物的提示，位置可能有bug
    {
        Text tempTextBox = Instantiate(textBox, new Vector3(0, 0, 0), transform.rotation) as Text;
        tempTextBox.transform.SetParent(canva.transform, false);
        tempTextBox.fontSize = 50;
        tempTextBox.text = "Not enough material";
        Destroy(tempTextBox, 2f);
    }
}
