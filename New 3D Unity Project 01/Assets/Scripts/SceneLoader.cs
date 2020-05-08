using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {
    [Header("Load")]
    public Text loadingText;
    public Slider loadingBar;
    public GameObject loadPanel;
    public string sceneName;

    public void Play() {
        Debug.Log("Play()");
        StartCoroutine(Loading());
    }
    private IEnumerator Loading() {
        Debug.Log("Loading()");
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        ao.allowSceneActivation = false;
        while (ao.isDone == false) {
            //loadingText.text = "LOADING " + ((ao.progress / 0.9f) * 100).ToString() + " %";
            //loadingBar.value = ao.progress / 0.9f;
            yield return new WaitForSeconds(0.025f);
            //if (ao.progress == 0.9f && Input.anyKey) ao.allowSceneActivation = true;
            if (ao.progress == 0.9f && loadPanel.GetComponent<Image>().color.a == 1f) ao.allowSceneActivation = true;
        }
    }

}
