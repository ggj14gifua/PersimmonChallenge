using UnityEngine;
using System.Collections;

public class TitleUI : MonoBehaviour {

	Rect startButtonRect;

	// Use this for initialization
	void Start () {
		float startButtonWidth = Screen.width * 0.30f;
		float startButtonHeight = Screen.height * 0.15f;
		startButtonRect = new Rect (Screen.width / 2.0f - startButtonWidth / 2.0f,
		                            ((Screen.height / 4.0f) * 3.0f) - startButtonHeight / 2.0f,
		                            startButtonWidth, startButtonHeight);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (GUI.Button (startButtonRect, "Start")) {
			Scene.NextScene = "Game";
			Scene.canNextScene = true;
		}
	}
}
