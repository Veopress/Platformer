using UnityEngine;
using System.Collections;

public class MemContinue : MonoBehaviour 
{

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	public void loadNextLevel()
	{
		if(Application.loadedLevelName.Equals("Final Level")){
			Application.Quit();
		}
		Application.LoadLevel (Application.loadedLevelName.Equals("yolo") ? "Level 2" : Application.loadedLevelName.Equals("Level 2") ? "Level 3" : Application.loadedLevelName.Equals("Level 3") ? "Level 4" : Application.loadedLevelName.Equals("Level 4") ? "Final Level" : "yolo");
	}
}
