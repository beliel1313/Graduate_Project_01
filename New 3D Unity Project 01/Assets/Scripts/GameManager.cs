using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    [Header("Mixer")]
    public AudioMixer mixer;
    public Slider bgmBar, sfxBar;
    [Header("Load")]
    public Text loadingText;
    public Slider loadingBar;
    public string sceneName;

    private bool isPaused = false;

    void Start() {
        float bgmValue;
        mixer.GetFloat("vBGM", out bgmValue);
        bgmBar.value = bgmValue;
        float sfxValue;
        mixer.GetFloat("vBGM", out sfxValue);
        bgmBar.value = sfxValue;
    }
    public void BGM_vol (float value)  {mixer.SetFloat("vBGM", value);}
    public void SFX_vol (float value)  {mixer.SetFloat("vSFX", value);}
    public void Play() {
        StartCoroutine(Loading());
    }
    private IEnumerator Loading() {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        ao.allowSceneActivation = false;
        while (ao.isDone == false) {
            loadingText.text ="LOADING " + ((ao.progress / 0.9f) * 100).ToString() + " %";
            loadingBar.value = ao.progress / 0.9f;
            yield return new WaitForSeconds(0.025f);
            if (ao.progress == 0.9f && Input.anyKey)  ao.allowSceneActivation = true;
        }
    }

    public void GamePause() {
        isPaused = !isPaused;
        if (isPaused == true) { Time.timeScale = 0; }
        else  { Time.timeScale = 1; }
    }

    public void GameQuit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
