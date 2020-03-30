using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationRewind : MonoBehaviour {

    private Animation backAnimation;
    private Animator backAnimator;

	// Use this for initialization
	void Start () {
        backAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayRewind() {
        backAnimation.Rewind("MenuSlideUp");
    }
}
