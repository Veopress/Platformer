﻿using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			if(SpoopyGo.deathcount>5)
			{
				Application.LoadLevel("EndScreen");
			}
			else Application.LoadLevel (Application.loadedLevel);
		}
	}
}
