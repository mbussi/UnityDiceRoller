using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewToggleBehavior : MonoBehaviour {
	private static readonly string PERSPECTIVE_TEXT = "Perspective\nView";
	private static readonly string ORTHOGRAPHIC_TEXT = "Orthographic\nView";
	Text childText;
	bool isPerspective;

	// Use this for initialization
	void Start () {
		childText = GetComponentInChildren<Text>();
		if (childText != null) {
			childText.text = PERSPECTIVE_TEXT;
		}
		isPerspective = true;
		Camera.main.orthographic = false;
		Camera.main.orthographicSize = 20.25f;
	}
	
	public void changeViewType() {
		isPerspective = !isPerspective;  // Alter the view type

		// and modify it
		if (isPerspective) {
			childText.text = PERSPECTIVE_TEXT;
			Camera.main.orthographic = false;
		} else {
			childText.text = ORTHOGRAPHIC_TEXT;
			Camera.main.orthographic = true;
		}
	}
}
