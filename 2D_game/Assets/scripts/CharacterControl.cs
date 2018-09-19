using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

	// Use this for initialization

	//player movement variables
	public float moveSpeed = 3;
	public float JumpHeight = 6; 

//player ground variables 
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	// //non-stick player 
	// private float moveVelocity;
	
	void Start () {
		
	}
	
	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space) && grounded) {
			Jump();
		}
		if(Input.GetKeyDown (KeyCode.D)) {
			MoveRight();
		}
	}
	public void Jump () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
	}
	public void MoveRight () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}
}
