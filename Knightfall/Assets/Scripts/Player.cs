using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed = 300f;						//Movement Speed of the Player
	public float jumpSpeed = 1900f; 					// Jump Speed of the Player
	public float airSpeedMultiplier = .3f; 				//Slows down player while in air
	public bool grounded; 								//Determine wether the player is on the ground or in the air
	public Vector2 maxVelocity = new Vector2(30, 50); 	// Maximum velocity of Player
	private Rigidbody2D rbody; 							// Reference to RigidBody for player physics
	private Animator animator; 							// Reference to animatior for player animation timings
	private PlayerController controller; 				//Reference to player controller class

	// Start is called at the beginning of the game for initialization
	void Start(){

														// Getters for game componets linked to player character
		rbody = GetComponent<Rigidbody2D>();
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		float forceX = 0f; 								// Declare and initialize the force acting on the player on the x axis.
		float forceY = 0f; 								// Declare and initialize the force acting on the player on the y axis.
		var absVelX = Mathf.Abs (rbody.velocity.x);
		var absVelY = Mathf.Abs (rbody.velocity.y);

		if (absVelY == 0) {
			grounded = true;
		} 
		else {
			grounded = false;
		}
			
		if (Input.GetKey ("d")) {
			if(absVelX <= maxVelocity.x)
				forceX = grounded ? moveSpeed : (moveSpeed * airSpeedMultiplier);
				transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		}
		if(Input.GetKey ("a")){
			if(absVelX <= maxVelocity.x)
				forceX = grounded ? -moveSpeed : (-moveSpeed * airSpeedMultiplier);
				transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
		}

		if (Input.GetKey("space")) {
			if(absVelY < maxVelocity.y)
				forceY = jumpSpeed;

		}

		if (Input.GetKey ("j")) {
			animator.SetBool ("Slashing", true);

		}
		else {
			animator.SetBool ("Slashing", false);
		}

		if (Input.GetKey ("k") && grounded && controller.moving.x == controller.moving.y) {
			animator.SetBool ("Thrusting", true);
			if (Input.GetKey ("d") || Input.GetKey ("a") || Input.GetKey("space"))
				forceX = 0f;
				forceY = 0f;

		}
		else {
			animator.SetBool ("Thrusting", false);
		}

		if (controller.moving.x != 0) {
			if (absVelX < maxVelocity.x) {

				forceX = grounded ? moveSpeed * controller.moving.x : (moveSpeed * controller.moving.x * airSpeedMultiplier);

				transform.localScale = new Vector3 (forceX > 0 ? 1.0f : -1.0f, 1.0f, 1.0f);
			}
			animator.SetInteger ("State", 1);
		} 

		else {
			animator.SetInteger ("State", 0);
		}

		if (absVelY > 0) {
			animator.SetBool("Airborne", true);
		}
		else{
			animator.SetBool("Airborne", false);
		}

		rbody.AddForce (new Vector2 (forceX, forceY));

	}
}
