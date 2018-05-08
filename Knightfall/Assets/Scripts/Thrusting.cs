using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrusting : MonoBehaviour {
	public Player player;
	public BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		collider.enabled = false;

	}
	// Update is called once per frame
	void Update () {
		if (player.thrusting)
			collider.enabled = true;
		else
			collider.enabled = false;
	}
}