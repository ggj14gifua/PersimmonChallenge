using UnityEngine;
using System.Collections;

public class GameScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// 0: Mouse left button
		// 1: Mouse right button
		// 2: Mouse center button
		if (Input.GetMouseButtonUp(0)) {
			Scene.canNextScene = true;
		}
	}
}
