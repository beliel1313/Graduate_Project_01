using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    private bool isPaused = false;
    public bool isMute = false;

    [Header("Static Value")]
    static public int moneyCount;
    static public int moneyLimit = 99999;

    [Header("Mixer")]
    public AudioMixer mixer;
    public Slider bgmBar, sfxBar;

    [Header("Text")]
    public Text textMoney;

    // Use this for initialization
    void Start() {
        //Audio
        float bgmValue;
        float sfxValue;
        mixer.GetFloat("vBGM", out bgmValue);
        mixer.GetFloat("vBGM", out sfxValue);
        bgmBar.value = bgmValue;
        bgmBar.value = sfxValue;

    }

    // Update is called once per frame
    void Update() {
        if (moneyCount <= moneyLimit)
        {
            textMoney.text = " X " + moneyCount.ToString();
        }

    }

    public void BGM_vol (float value)
    {
        mixer.SetFloat("vBGM", value);
    }

    public void SFX_vol (float value)
    {
        mixer.SetFloat("vSFX", value);
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
