using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {


	[HideInInspector] public bool facingRight=true;
	[HideInInspector] public bool jump = true;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;

	public bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;



	// Use this for initialization
	void Awake () {

		anim = GetComponent<Animator> ();
		rb2d = GetComponent < Rigidbody2D> ();
		
	}//end awake
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		// Linecast returns true if something hits the line called in parameter

		//transform.position is position of hero
		//groundCheck is the feet
		// LayerMask is only use the Ground layer

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;  
			//no double jump
			//"Jump" button set in Input

		}//end if for Jump
	}//end Update


	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");  //gets number from -1 to 1 of where here is on horz

		anim.SetFloat("Speed", Mathf.Abs(h)); // sets speed and makes only use a positive

		// if speed is under max then add force
		if( h * rb2d.velocity.x < maxSpeed){
			rb2d.AddForce (Vector2.right * h * moveForce );
		}//end if 

		//check if speed is over under max then set to max ( only comparing postitives)
		if(Mathf.Abs(rb2d.velocity.x) >maxSpeed){
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
			//(Mathf.Sign (rb2d.velocity.x)// returns 1 or -1 depending on left or right
		}//end if

		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();

		//if jump is true for this frame
		if(jump){
			anim.SetTrigger ("Jump");// play jump animation
			rb2d.AddForce(new Vector2(0f,jumpForce));
			jump = false;

		}//end if
			
	}//end fixed Update - put physics code in fixed update
		




	void Flip(){
		facingRight = !facingRight;
		//change the bool to the opposite
		Vector3 theScale = transform.localScale; // gets the current scale and stores it
		theScale.x *= -1; //flips the scale and flips the hero
		transform.localScale =theScale;

	}//end flip

}//end clase
