using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallaxing : MonoBehaviour {

	public Transform[] backgroundElements; 		// Elements in background
	public float[] scales;
	public float smoothing = 1f; 				// Must Be greater than 0


	private Transform cameraTrans; 				// Reference to the transformation (position) of the camera
	private Vector3 prevCameraTrans; 			// Reference to the previous camera transfromation (position)

	void Awake(){

		cameraTrans = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		prevCameraTrans = cameraTrans.position;

		scales = new float[backgroundElements.Length];

		for (int i = 0; i < backgroundElements.Length; i++) {
			scales [i] = 1000 / backgroundElements [i].position.z;
		}
			
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < backgroundElements.Length; i++) {
			float parallax = (prevCameraTrans.x - cameraTrans.position.x) * scales[i];
			float backgroundTargetTransX = backgroundElements[i].position.x + parallax;

			Vector3 backgroundTargetTrans = new Vector3 (backgroundTargetTransX, backgroundElements [i].position.y, backgroundElements [i].position.z);

			backgroundElements [i].position = Vector3.Lerp (backgroundElements[i].position, backgroundTargetTrans, smoothing * Time.deltaTime);
		}

		prevCameraTrans = cameraTrans.position;
	}
}
