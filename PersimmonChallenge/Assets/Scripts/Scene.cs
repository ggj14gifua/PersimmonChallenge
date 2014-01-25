using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {

	public string NextScene;
	public static bool canNextScene = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (canNextScene) {
			Application.LoadLevel(NextScene);
			canNextScene = false;
		}
	}
}
