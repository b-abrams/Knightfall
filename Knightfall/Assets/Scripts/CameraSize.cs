using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour {

	public static float pixelsToUnits = 1f;
	public static float scale = 1f;
	public Resolution nativeResolution;

	// Use this for initialization
	void Awake () {
		nativeResolution = Screen.currentResolution;
		var camera = GetComponent<Camera> ();
		if (camera.orthographic) {
			scale = Screen.height * 1.5f / nativeResolution.height;
			pixelsToUnits *= scale;
			camera.orthographicSize = (Screen.height/ 2f) / pixelsToUnits;
		}

	}

}
