using UnityEngine;
using System.Collections;

public class endgame : MonoBehaviour 
{

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	public void end()
	{
		Application.Quit ();
	}

	public void replay()
	{
		Application.LoadLevel ("yolo");
	}

	public void menu()
	{
		Application.LoadLevel ("OpeningScreen");
	}
}
