using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    public bool actionButton;
    public float absVelX = 0f;
    public float absVelY = 0f;
    public bool idle;
    public float jumping = 1;

    private Rigidbody2D body2D;
    void Awake(){
        body2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)){

            actionButton = Input.GetKeyDown(KeyCode.Space);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            actionButton = Input.GetKeyDown(KeyCode.LeftArrow);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            actionButton = Input.GetKeyDown(KeyCode.RightArrow);
        }
    }

    void FixedUpdate()
    {
        absVelX = System.Math.Abs(body2D.velocity.x);
        absVelY = System.Math.Abs(body2D.velocity.y);

        idle = absVelX <= jumping && absVelY <= jumping;
    }
}
