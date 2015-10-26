using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	
	private bool alerted = false;
	private Rigidbody2D rb;
	public float speed = 5.0F;
	private MonoBehaviour pChecker;
	public GameObject player;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		pChecker = player.GetComponent<MonoBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (((SpoopyGo)pChecker).getPhased()) {
			alerted = false;
		}
		if (alerted) {
			if (player.transform.position.x < transform.position.x) {
				print (player.transform.position.x + ", " + transform.position.x);
				rb.velocity = new Vector2(-speed, 0.0F);
			} else if (player.transform.position.x > transform.position.x) {
				print ("WHY!");
				rb.velocity = new Vector2(speed, 0.0F);
			} else {
				rb.velocity = new Vector2(0F,0F);
			}
		} 
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			alerted = true;
		}
	}

}
