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

    [Header("Click")]
    public GameObject[] ctActive = new GameObject[1];
    public GameObject[] ctInactive = new GameObject[1];

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
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            ctActive[0].SetActive(true);
            ctInactive[0].SetActive(false);
        }

    }
}
