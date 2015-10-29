﻿using UnityEngine;
using System.Collections;

public class SpoopyGo : MonoBehaviour {

	Rigidbody2D rb;
	Animator anim;
	public bool leftKey= false, rightKey = false, upKey = false, isSecondJump = false, firstJump = true, phaseKey = false, facingRight = false, stale = false, grounded = false, invis = false, i1 = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask groundThings;
	private SpriteRenderer ghost;
	public float forceMagnitude = 5F, maxVelocity = 6F;
	private int timer = 0;
	
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		ghost = this.GetComponent<SpriteRenderer> ();
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundThings);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", rb.velocity.y);
		anim.SetBool ("Invis", invis);
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		if (move > 0 && facingRight)
			Flip ();
		else if (move < 0 && !facingRight)
			Flip ();
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D c){
		if (phaseKey && c.tag.Equals ("Phasable")) {
			GetComponent<BoxCollider2D> ().enabled = false;
			return;
		} else {
			GetComponent<BoxCollider2D> ().enabled = true;
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.collider.tag.Equals ("enemy")) {
			die ();
		} else if (c.collider.tag.Equals ("Memory")) { 
			loadNextLevel();
		}
		isSecondJump = false;
		firstJump = true;
	}

<<<<<<< HEAD
	void phase()
	{
		invis = true;
		ghost.color = new Color (1f, 1f, 1f, 0.5f);
=======
	void loadNextLevel(){
		if(Application.loadedLevelName.Equals("Final Level")){
			Application.Quit();
		}
		Application.LoadLevel (Application.loadedLevelName.Equals("yolo") ? "Level 2" : Application.loadedLevelName.Equals("Level 2") ? "Level 3" : Application.loadedLevelName.Equals("Level 3") ? "Level 4" : Application.loadedLevelName.Equals("Level 4") ? "Final Level" : "yolo");
	}

	void phase(){
>>>>>>> d894cc81c61520b70c9f7f11a89a91e50bf8a5fb
		rb.gravityScale = 0.5f;
	}

	void die(){
		Application.LoadLevel(Application.loadedLevelName);
	}

	public bool getPhased() {
		return phaseKey;
	}

	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;

		//Phasing
		if (phaseKey) {
			phase ();
		}

		if (Input.GetAxis ("Fire3") == 1)
		{
			invis = true;
			phaseKey = true;
		}
		if (Input.GetAxis ("Fire3") != 1) 
		{
			invis = false;
			phaseKey = false;
			ghost.color = new Color (1f, 1f, 1f, 1f);
		}





		// Movement
		
		/*if (Input.GetAxis("Horizontal") == -1)
			leftKey=true;
		if (Input.GetAxis("Horizontal") != -1)
			leftKey=false;
		if (Input.GetAxis("Horizontal") == 1)
			rightKey=true;
		if (Input.GetAxis("Horizontal") != 1)
			rightKey=false;*/
		if (Input.GetAxis ("Jump") == 1 && stale == false) {
			upKey = true;
		}
		if (Input.GetAxis ("Jump") != 1) {
			upKey = false;
			stale = false;
		}
		
		if (upKey && timer <= 0 && !isSecondJump) {
			anim.SetBool("Ground", false);
			stale = true;
			upKey = false;
			rb.velocity = new Vector2(rb.velocity.x,0);
			rb.AddRelativeForce (new Vector2 (0, 300));
			timer = 20;
			if(!firstJump){
				isSecondJump = true;
			}else{
				firstJump = false;
			}
		}
		if (timer > 0)
			timer--;
		rb.velocity = (new Vector2 (forceMagnitude * Input.GetAxis("Horizontal"),rb.velocity.y));

		if (Mathf.Abs (rb.velocity.magnitude) / Time.deltaTime > maxVelocity)
			rb.velocity.Scale (new Vector2 (maxVelocity * Time.deltaTime, maxVelocity * Time.deltaTime));
	}
}
