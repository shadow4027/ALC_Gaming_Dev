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
	private bool doubleJump = true;

	// //non-stick player 
	private float moveVelocity;
	
	void Start () {
		
	}
	
	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	// Update is called once per frame
	void Update () {
		if(grounded) {
			doubleJump = false;
		}
		// moveVelocity = 0f;
		if(Input.GetKeyDown (KeyCode.W) && !doubleJump && !grounded ) {
			Jump();
			doubleJump = true;
		}
		if(Input.GetKeyDown (KeyCode.W) && grounded) {
			Jump();
		}
		if(Input.GetKeyDown (KeyCode.D)) {
			MoveRight();
		}
		if(Input.GetKeyDown (KeyCode.A)) {
			MoveLeft();
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		moveVelocity = 0;
		}
	}
	public void Jump () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
	}
	public void MoveRight () {
		moveVelocity = moveSpeed;
		Debug.Log("moves right");
	}
	public void MoveLeft () {
		moveVelocity = -moveSpeed;
		Debug.Log("moves right");
	}
}
