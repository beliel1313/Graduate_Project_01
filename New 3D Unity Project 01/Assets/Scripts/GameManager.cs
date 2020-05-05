using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    private bool isPaused = false;

    [Header("Mixer")]
    public AudioMixer mixer;
    public Slider bgmBar, sfxBar;

    void Start()
    {
        float bgmValue;
        float sfxValue;

        mixer.GetFloat("vBGM", out bgmValue);
        mixer.GetFloat("vBGM", out sfxValue);

        bgmBar.value = bgmValue;
        bgmBar.value = sfxValue;

    }

    public void BGM_vol (float value)  {mixer.SetFloat("vBGM", value);}
    public void SFX_vol (float value)  {mixer.SetFloat("vSFX", value);}

    public void GamePause()
    {
        Debug.Log("GamePause()");
        isPaused = !isPaused;
        if (isPaused == true) { Time.timeScale = 0; }
        else  { Time.timeScale = 1; }

    }

    public void GameQuit()
    {
        Debug.Log("GameQuit()");
        Application.Quit();

    }
}
