using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
	public AudioMixer mixer;
	public Slider bgmBar, sfxBar;

	// Use this for initialization
	void Start () {
		float bgmValue;
		float sfxValue;
		mixer.GetFloat("vBGM", out bgmValue);
		mixer.GetFloat("vBGM", out sfxValue);
		bgmBar.value = bgmValue;
		bgmBar.value = sfxValue;

	}

	public void BGM_vol(float value)
	{
		mixer.SetFloat("vBGM", value);
	}

	public void SFX_vol(float value)
	{
		mixer.SetFloat("vSFX", value);
	}

}
