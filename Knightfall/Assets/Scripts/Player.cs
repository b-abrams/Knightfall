using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed = 1800f;						//Movement Speed of the Player
	public float jumpSpeed = 2400f; 					// Jump Speed of the Player
	public float airSpeedMultiplier = .2f; 				//Slows down player while in air
	public bool grounded; 								//Determine wether the player is on the ground or in the air
	public Vector2 maxVelocity = new Vector2(200, 250); 	// Maximum velocity of Player
	public bool slashing = false;
	public bool thrusting = false;
	public CircleCollider2D debris;
	private float maxJumpHeight = 200f;
	private float yInit = 0f;
	private bool maxHeightReached = false;
	private Rigidbody2D rbody; 							// Reference to RigidBody for player physics
	private Animator animator; 							// Reference to animatior for player animation timings
	private PlayerController controller; 				//Reference to player controller class
	private BoxCollider2D collider;

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

		if (grounded) {
			yInit = rbody.position.y;
			maxHeightReached = false;
		}
			
		if (Input.GetKey ("d") && !thrusting) {
			if(absVelX <= maxVelocity.x)
				forceX = grounded ? moveSpeed : (moveSpeed * airSpeedMultiplier);
				transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
		}
		if(Input.GetKey ("a") && !thrusting){
			if(absVelX <= maxVelocity.x)
				forceX = grounded ? -moveSpeed : (-moveSpeed * airSpeedMultiplier);
				transform.localScale = new Vector3 (-2.0f, 2.0f, 2.0f);
		}

		if (Input.GetKey("space") && grounded) {
			if (absVelY < maxVelocity.y && !maxHeightReached)
				forceY = jumpSpeed;
		}
		if (Input.GetKey("space") && !grounded) {
			if (absVelY < maxVelocity.y && !maxHeightReached)
				forceY = jumpSpeed;
			if (!maxHeightReached && rbody.position.y - yInit >= maxJumpHeight)
				maxHeightReached = true;
		}
			
		if (Input.GetKey ("j")) {
			animator.SetBool ("Slashing", true);
			slashing = true;

		}
		else {
			animator.SetBool ("Slashing", false);
			slashing = false;
		}

		if (controller.moving.x != 0) {
			if (absVelX < maxVelocity.x) {

				forceX = grounded ? moveSpeed * controller.moving.x : (moveSpeed * controller.moving.x * airSpeedMultiplier);

				transform.localScale = new Vector3 (forceX > 0 ? 2.0f : -2.0f, 2.0f, 2.0f);
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
		if(thrusting && (Input.GetKey ("d") || Input.GetKey ("a") || Input.GetKey ("space"))) {
			forceX = 0f;
			forceY = 0f;
		}
		else if (Input.GetKey ("k") && grounded && controller.moving.x == controller.moving.y) {
			animator.SetBool ("Thrusting", true);
			thrusting = true;
		}
		else {
			animator.SetBool ("Thrusting", false);
			thrusting = false;
		}
		rbody.AddForce (new Vector2 (forceX, forceY));

		if (collider.IsTouching (debris)) {
			debris.enabled = false;
		}
	}
}
