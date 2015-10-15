using UnityEngine;
using System.Collections;

public class fallingPlatform : MonoBehaviour {

	public Rigidbody2D player;
	public float fallTime = 1.0F;
	private float stepTime = -1.0F;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (stepTime != -1.0F) {
			if (fallTime + stepTime >= Time.time) {
				rb.gravityScale.Equals(2.0F);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "player") {
			if (stepTime != -1.0F) {
				stepTime = Time.time;
			}
		}
	}
}
