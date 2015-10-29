using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class play : MonoBehaviour {

	public AudioSource audio1;
	void Start () 
	{
	}

	void Update () 
	{
	
	}

	public void playGame()
	{
		DontDestroyOnLoad(audio1);
		audio1.Play ();
		Application.LoadLevel ("yolo");
	}
}
