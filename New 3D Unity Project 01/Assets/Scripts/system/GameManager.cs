using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private bool isPaused = false;
    public bool isMute = false;

    [Header("Public Value")]
    static public int moneyCount;
    static public int moneyLimit = 9999;

    [Header("Text")]
    public Text textMoney;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (moneyCount <= moneyLimit)
        {
            textMoney.text = "" + moneyCount.ToString();
        }

    }

    public void GamePause()
    {
        Debug.Log("GamePause()");
        isPaused = !isPaused;
        if (isPaused == true) Time.timeScale = 0; 
        else Time.timeScale = 1; 
    }

    public void GameQuit()
    {
        Debug.Log("GameQuit()");
        Application.Quit();
    }
}
