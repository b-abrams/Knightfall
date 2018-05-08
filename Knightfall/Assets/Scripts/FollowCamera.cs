using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
	public SpriteRenderer background;
	public Transform cameraTrans, backgroudTrans;
	public float posX, posY, posZ, initY;

	void Awake(){
		background = GetComponent<SpriteRenderer> ();
	}

	// Use this for initialization
	void Start () {
		cameraTrans = Camera.main.transform;

		var width = background.sprite.bounds.size.x;
		var height = background.sprite.bounds.size.y;

		var worldScreenHeight = Camera.main.orthographicSize * 2.0f;
		var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		backgroudTrans.localScale = new Vector3 (1.2f * worldScreenWidth / width, 1.2f * worldScreenHeight / height, backgroudTrans.localScale.z);


		posX = cameraTrans.position.x;
		posY = cameraTrans.position.y;
		posZ = backgroudTrans.position.z;
		initY = posY;

	}
	
	// Update is called once per frame
	void Update () {
		backgroudTrans.position = new Vector3 (posX, posY, posZ);
		posX = cameraTrans.position.x;
		if(cameraTrans.position.y >= initY)
			posY = cameraTrans.position.y;
	}
}
