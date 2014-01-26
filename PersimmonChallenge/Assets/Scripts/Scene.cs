using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {

	public static bool canNextScene = false;
	public static bool isFadeIn;
	public static bool isFadeOut;
	public static string NextScene;

	public Texture2D blackTexture;
	private float alpha;
	private bool canNext = false;

	// Use this for initialization
	void Start () {

		alpha = 1;
		isFadeIn = true;
		isFadeOut = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (canNextScene) {
			isFadeOut = true;
		}
		if (canNext) {
			Application.LoadLevel( NextScene );
			canNextScene = false;
		}
	}

	void OnGUI () {
		var dim=Mathf.Clamp01(Time.deltaTime);

		if (isFadeIn) {
			alpha-=dim;
			if (alpha < 0) {
				isFadeIn = false;
				alpha = 0;
			}
		}
		else if (isFadeOut) {
			alpha+=dim;
			if (alpha >= 1) {
				canNext = true;
				isFadeOut = false;
				alpha = 1;
			}
		}

		GUI.color = new Color(0, 0, 0, alpha);
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), blackTexture );
	}
}
