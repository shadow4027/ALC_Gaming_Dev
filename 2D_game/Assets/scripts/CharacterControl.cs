using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
// Player Movement Variables
	public int MoveSpeed;
	public float JumpHeight;
	private bool CanDoubleJump;
	//Player grounded variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	public Vector3 Position;
	private float XStart, YStart;
	// Use this for initialization
	void Start () {
		Position = transform.position;
		XStart = Position.x;
		YStart = Position.y;
	}
	

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {

		// This code makes the character jump
		if(Input.GetKeyDown (KeyCode.W)&& grounded){
			CanDoubleJump = true;
			Jump();
		}

		// This code makes the character move from side to side using the A&D keys
		if(Input.GetKey (KeyCode.D)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			
		}
		if(Input.GetKey (KeyCode.A)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		if(Input.GetKey (KeyCode.R)){
			Position.x = XStart;
			Position.y = YStart;
			transform.position = Position;
		}
		if (GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(5f,5f,1f);

		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-5f,5f,1f);

	}

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
	}
}