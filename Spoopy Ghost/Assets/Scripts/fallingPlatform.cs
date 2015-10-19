using UnityEngine;
using System.Collections;

public class fallingPlatform : MonoBehaviour {

	public float fallTime = 1.0F;
	public float stepTime = -1.0F;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (stepTime != -1.0F) {
			if (fallTime + stepTime <= Time.time) {
				rb.isKinematic = false;
				rb.gravityScale = 2.0F;
				GetComponent<BoxCollider2D> ().enabled = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			if (stepTime == -1.0F) {
				stepTime = Time.time;
			}
		}
	}
}
