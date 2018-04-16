using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public float jumpSpeed = 400f;

    private Rigidbody2D body2D;
    private PlayerState playerState;
	
    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }
	// Update is called once per frame
	void Update () {
        if (playerState.idle)
        {
            if(playerState.actionButton = Input.GetKeyDown(KeyCode.Space))
            {
                body2D.velocity = new Vector2(0, jumpSpeed);
            }
        }
        if (!playerState.idle)
        {
            if (playerState.actionButton = Input.GetKeyDown(KeyCode.Space))
            {
                body2D.velocity = new Vector2(playerState.absVelX, jumpSpeed);
            }
        }
    }
}
