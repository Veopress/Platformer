using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	
	private bool alerted = false;
	public bool facingRight = false;
	private Rigidbody2D rb;
	public float speed = 5.0F;
	private MonoBehaviour pChecker;
	public GameObject player;
	Animator anim;
	public AudioSource MeowTime;


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		pChecker = player.GetComponent<MonoBehaviour> ();
		anim = GetComponent<Animator> ();

	}

	void FixedUpdate(){
		float move = rb.velocity.x;
		anim.SetFloat("Speed", Mathf.Abs (move));
		anim.SetBool ("Alerted", alerted);
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
	
	// Update is called once per frame
	void Update () {
		if (((SpoopyGo)pChecker).getPhased()) {
			alerted = false;
		}
		if (alerted) {

			if (player.transform.position.x < transform.position.x) {
				rb.velocity = new Vector2(-speed, 0.0F);
			} else if (player.transform.position.x > transform.position.x) 
			{
				rb.velocity = new Vector2(speed, 0.0F);
			} else {
				rb.velocity = new Vector2(0F,0F);
			}
		} 
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			if(alerted == false){
				anim.applyRootMotion = true;
			}
			alerted = true;
			Meow ();
		}
	}

	IEnumerator Meow()
	{
		print (Time.time);
		yield return new WaitForSeconds (1.0f);
		MeowTime.Play ();
		print (Time.time);

	}

}
