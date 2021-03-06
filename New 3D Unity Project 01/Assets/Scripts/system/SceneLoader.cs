﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [Header("Load")]
    // public Text loadingText;
    // public Slider loadingBar;
    public GameObject loadPanel;
    public string sceneName;
    public StageProcess process;

    public void Play(string s)
    {
        // Debug.Log("Play");
        loadPanel.SetActive(true);
        sceneName = s;

        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        // Debug.Log("Loading()");
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        ao.allowSceneActivation = false;
        while (ao.isDone == false) {
            // loadingText.text = "LOADING " + ((ao.progress / 0.9f) * 100).ToString() + " %";
            // loadingBar.value = ao.progress / 0.9f;
            // if (ao.progress == 0.9f && Input.anyKey) ao.allowSceneActivation = true;
            yield return new WaitForSeconds(0.025f);
            if (ao.progress == 0.9f && loadPanel.GetComponent<Image>().color.a == 1f) {
                ao.allowSceneActivation = true;
            }
        }
    }

}
