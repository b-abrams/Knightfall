using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	private Camera camera;
	private Transform trans;

	void Awake(){
		camera = GetComponent<Camera>();
		camera.orthographicSize = (Screen.height / 2f) / 100f;
	}
	// Use this for initialization
	void Start () {
		trans = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (trans.position.x, trans.position.y, transform.position.z);
	}
}
