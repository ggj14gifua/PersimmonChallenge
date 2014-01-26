using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
	public static bool s_pauseFlag = false;
	string SceneName;
	bool pauseFlag = false;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( Application.loadedLevelName == "Game"
		    && Input.GetMouseButtonUp( 0 ) )
		{
			if ( pauseFlag == false )
			{
				pauseFlag = true;
			}
			else
			{
				pauseFlag = false;
			}
		}
		
		s_pauseFlag = pauseFlag;
	}
}
