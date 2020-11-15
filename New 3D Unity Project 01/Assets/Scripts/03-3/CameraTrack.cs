using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack: MonoBehaviour {
	public Camera camera;
	public Transform target;
	public bool allowTrack;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (allowTrack == true) 
		{
			if (camera.transform.position.x >= 0 && target.position.x >= 0) 
			{
			camera.transform.position = new Vector3(target.position.x, 1,-10);
			// print("TGT.X " + target.position.x);
			// print("CAM.X " + camera.transform.position.x);

			}
		}
	}

}
