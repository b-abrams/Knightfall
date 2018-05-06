using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	public Player player;
	public BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		//player = GetComponent<Player> ();
		//collider = GetComponent<BoxCollider2D> ();
		collider.enabled = false;

	}
	// Update is called once per frame
	void Update () {
			if (player.slashing)
				collider.enabled = true;
			if (!player.slashing)
				collider.enabled = false;
			if (player.thrusting)
				collider.enabled = true;
			if (!player.thrusting)
				collider.enabled = false;
	}
}
