using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	
	private bool alerted = false;
	private Rigidbody2D rb;
	public float speed = 5.0F;
	public SpoopyGo player;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.getPhased()) {
			alerted = false;
		}
		if (alerted) {
			if (player.transform.position.x < rb.transform.position.x) {
					rb.velocity = new Vector2(-speed, 0.0F);
			} else {
				rb.velocity = new Vector2(speed, 0.0F);
			}
		} else {
			rb.velocity.Set (0F,0F);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			alerted = true;
		}
	}
}
