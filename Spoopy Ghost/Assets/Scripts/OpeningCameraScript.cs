using UnityEngine;
using System.Collections;

public class OpeningCameraScript : MonoBehaviour 
{
	public GameObject target;
	private float speedMod = 0.5f;
	private Vector3 point;
	
	void Start () 
	{
		point = target.transform.position;
		transform.LookAt(point);
	}
	
	void Update () 
	{
		transform.RotateAround (point,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * speedMod);
	}

	void LateUpdate()
	{
		Vector3 temp = transform.position; 
		temp.y = 50.0f; 
		transform.position = temp; 
	}
}
