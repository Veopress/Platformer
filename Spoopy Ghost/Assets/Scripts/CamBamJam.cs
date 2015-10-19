using UnityEngine;
using System.Collections;

public class CamBamJam : MonoBehaviour {

	public GameObject spoopy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (spoopy.transform.position.x > 2 + this.transform.position.x)
			this.transform.position = new Vector3 (this.transform.position.x + 0.1f, this.transform.position.y, -10);
		if (spoopy.transform.position.x < -2 + this.transform.position.x)
			this.transform.position = new Vector3 (this.transform.position.x - 0.1f, this.transform.position.y, -10);
		if (spoopy.transform.position.y > 2 + this.transform.position.y)
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 0.1f, -10);
		if (spoopy.transform.position.y < -2 + this.transform.position.y)
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - 0.1f, -10);
	}
}
