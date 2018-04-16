using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed = 200f;
    private Rigidbody2D body2D;
    private PlayerState playerState;

    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update () {

        if (playerState.actionButton = Input.GetKeyDown(KeyCode.RightArrow))
        {
            body2D.velocity = new Vector2(moveSpeed, 0);
        }
        if (playerState.actionButton = Input.GetKeyDown(KeyCode.LeftArrow))
        {
            body2D.velocity = new Vector2(-moveSpeed, 0);
        }

    }
}
