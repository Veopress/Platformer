using UnityEngine;
using System.Collections;

public class SpoopyGo : MonoBehaviour {

	Rigidbody2D rb;
	public bool leftKey= false, rightKey = false, upKey = false, isSecondJump = false, firstJump = true, phaseKey = false;
	public float forceMagnitude = 13f, maxVelocity = 10f;
	private int timer = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
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
		isSecondJump = false;
		firstJump = true;
	}

	void phase(){
		rb.gravityScale = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;

		//Phasing

		if (Input.GetAxis("Fire3") == 1)
			phaseKey = true;
		if (Input.GetAxis("Fire3") != 1)
			phaseKey = false;

		if (phaseKey) {
			phase();
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
		if (Input.GetAxis("Jump") == 1)
			upKey = true;
		if (Input.GetAxis("Jump") != 1)
			upKey = false;
		
		if (upKey && timer <= 0 && !isSecondJump) {
			rb.AddRelativeForce (new Vector2 (0, forceMagnitude * 30));
			timer = 50;
			if(!firstJump){
				isSecondJump = true;
			}else{
				firstJump = false;
			}
		}
		if (timer > 0)
			timer--;
		rb.AddRelativeForce (new Vector2 (forceMagnitude * Input.GetAxis("Horizontal"),0));

		if (Mathf.Abs (rb.velocity.magnitude) / Time.deltaTime > maxVelocity)
			rb.velocity.Scale (new Vector2 (maxVelocity * Time.deltaTime, maxVelocity * Time.deltaTime));
	}
}
