using UnityEngine;
using UnityEngine.Audio;     // Use audio API.
using UnityEngine.UI;       // Use UI API.
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Text loadingText;
    public Slider loadingBar;

    public void BGM_vol (float value)  {mixer.SetFloat("vBGM", value);}
    public void SFX_vol (float value)  {mixer.SetFloat("vSFX", value);}
    public void Play()
    {
        SceneManager.LoadScene("NewScene01");
        StartCoroutine(Loading());
    }
    private IEnumerator Loading()
    {
        //  print("Test 1");
        //  yield return new WaitForSeconds(1);
        //  print("Test 2");
        AsyncOperation ao = SceneManager.LoadSceneAsync("NewScene01");
        ao.allowSceneActivation = false;
        while (ao.isDone == false)
        {
            loadingText.text ="LOADING " + ((ao.progress / 0.9f) * 100).ToString() + " %";
            loadingBar.value = ao.progress / 0.9f;
            yield return new WaitForSeconds(0.025f);
            if (ao.progress == 0.9f && Input.anyKey)  ao.allowSceneActivation = true;
        }
    }
}
