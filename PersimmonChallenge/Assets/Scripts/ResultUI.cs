using UnityEngine;
using System.Collections;

public class ResultUI : MonoBehaviour {

	public Texture2D restart;
	public Texture2D next;
	public Texture2D select;

	Rect restartButtonRect;
	Rect nextButtonRect;
	Rect selectButtonRect;

	// Use this for initialization
	void Start () {
		float buttonWidth = Screen.height * 0.25f;
		float buttonHeight = Screen.height * 0.25f;
		restartButtonRect = new Rect (Screen.width / 2.0f - buttonWidth / 2.0f,
		                            ((Screen.height / 4.0f) * 3.0f) - buttonHeight / 2.0f,
		                            buttonWidth, buttonHeight);
		nextButtonRect = new Rect (Screen.width / 4.0f - buttonWidth / 2.0f,
		                            ((Screen.height / 4.0f) * 3.0f) - buttonHeight / 2.0f,
		                            buttonWidth, buttonHeight);
		selectButtonRect = new Rect ((Screen.width / 4.0f) * 3.0f - buttonWidth / 2.0f,
		                            ((Screen.height / 4.0f) * 3.0f) - buttonHeight / 2.0f,
		                            buttonWidth, buttonHeight);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (GUI.Button (restartButtonRect, restart)) {
			Scene.NextScene = "Game";
			Scene.canNextScene = true;
		}
		if (GUI.Button (nextButtonRect, next)) {
			Scene.NextScene = "Game";
			Scene.canNextScene = true;
		}
		if (GUI.Button (selectButtonRect, select)) {
			Scene.NextScene = "Title";
			Scene.canNextScene = true;
		}
	}
}
