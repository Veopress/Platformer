using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	
	private bool alerted = false;
	private Rigidbody2D rb;
	private bool movingLeft = false;
	private bool movingRight = false;
	public float speed = 5.0F;
	public Rigidbody2D player;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (alerted) {
			if (player.transform.position.x > rb.transform.position.x) {
				if (!movingLeft) {
					rb.velocity.Set (speed, 0.0F);
					movingRight = false;
					movingLeft = true;
				}
			} else {
				if (!movingRight) {
					rb.velocity.Set (speed, 0.0F);
					movingRight = true;
					movingLeft = false;
				}
			}
		} else {
			movingLeft = false;
			movingRight = false;
			rb.velocity.Set (0F,0F);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "player") {
			alerted = true;
		}
	}
}
