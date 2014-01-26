using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour {

	public static string preStage;
	public GameObject _1;
	public GameObject _2;
	public GameObject _3;
	public GameObject _4;
	public GameObject _5;
	public GameObject _6;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var collition2d  = Physics2D.OverlapPoint(tapPoint);
			var hitObject  = Physics2D.Raycast(tapPoint,-Vector2.up);
			if (hitObject) {
				Debug.Log("hit object is " + hitObject.collider.gameObject.name);
			}

			if (hitObject.collider.gameObject == _1) {
				Scene.NextScene = "Stage1";
				preStage = "Stage1";
				Scene.canNextScene = true;
			}
			if (hitObject.collider.gameObject == _2) {
				Scene.NextScene = "Stage2";
				preStage = "Stage2";
				Scene.canNextScene = true;
			}
			if (hitObject.collider.gameObject == _3) {
				Scene.NextScene = "Stage3";
				preStage = "Stage3";
				Scene.canNextScene = true;
			}
			if (hitObject.collider.gameObject == _4) {
				Scene.NextScene = "Stage4";
				preStage = "Stage4";
				Scene.canNextScene = true;
			}
			if (hitObject.collider.gameObject == _5) {
				Scene.NextScene = "Stage5";
				preStage = "Stage5";
				Scene.canNextScene = true;
			}
			if (hitObject.collider.gameObject == _6) {
				Scene.NextScene = "Stage6";
				preStage = "Stage6";
				Scene.canNextScene = true;
			}
		}
	}
}
