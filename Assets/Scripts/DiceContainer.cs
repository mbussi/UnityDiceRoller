using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiceContainer : MonoBehaviour {
	private readonly float THRESHOLD = 2.5f;
	public float diceScale;

	public Vector2 bounds, screenSize;
	DiceOptionsBehavior diceMenu;
	GameObject optionsMenu, backgroundMenu;
	ButtonBehavior toggleOptionsButton;

	private Vector3 lastFrameAcceleration;

	// Use this for initialization
	void Start () {
		var slider = GameObject.FindGameObjectWithTag ("Menu_Container").transform.FindChild ("User_Options").FindChild ("Dice_Size").FindChild ("Slider").GetComponent <Slider>();
		updateDiceScale (slider.value);
		bounds.x = (Camera.main.orthographicSize * Camera.main.aspect);
		bounds.y = (Camera.main.orthographicSize);
		screenSize.y = Screen.height;
		screenSize.x = Screen.width;
		optionsMenu = GameObject.FindGameObjectWithTag ("Menu_Container").transform.FindChild ("User_Options").gameObject;
		diceMenu = GameObject.FindGameObjectWithTag ("Menu_Container").transform.FindChild ("Dice_Options").GetComponent<DiceOptionsBehavior>();
		backgroundMenu = GameObject.FindGameObjectWithTag ("Menu_Container").transform.FindChild ("Background_Options").gameObject;
		toggleOptionsButton = GameObject.FindGameObjectWithTag ("Permanent_Options").transform.FindChild ("Toggle_Options").GetComponent<ButtonBehavior> ();
		lastFrameAcceleration = new Vector3 (0, 0, 0);
	}

	/// <summary>
	/// Step 1: check if any dice have been clicked.  If so, display their options.
	/// Step 2: calaulcate the jerk of the accelerometer.  If it exceeds a threshold, shake the dice.
	/// </summary>
	void Update () {
		// Step 1
		if(Input.GetMouseButtonDown(0) && !diceMenu.isActive() && !optionsMenu.activeSelf && !backgroundMenu.activeSelf) {
			if(!toggleOptionsButton.isClicked(Input.mousePosition)) {
				selectDice ();
			}
		}

		// Step 2
		Vector3 jerk = calculateJerk(Input.acceleration);
		if ((Mathf.Abs (jerk.x) + Mathf.Abs (jerk.y) + Mathf.Abs (jerk.z)) > THRESHOLD) {
			shakeAllDice(jerk);
		} else if (Input.GetKeyDown("w")) {
			shakeAllDice(new Vector3(1f, 1f, 1f));
		}
	}

	/// <summary>
	/// get the current acceleration.  subtract the previous frame's acceleration from it
	/// </summary>
	private Vector3 calculateJerk(Vector3 thisFrameAcceleration) {
		Vector3 jerk = thisFrameAcceleration - lastFrameAcceleration;
		lastFrameAcceleration = thisFrameAcceleration;
		return jerk;
	}

	private void selectDice() {
		Vector2 actualPosition = translateTouchPoints (Input.mousePosition);
		foreach (Transform child in transform) {
			float tolerance = child.transform.localScale.x * 2.3f;
			float differenceX = Mathf.Abs(child.transform.position.x - actualPosition.x);
			float differenceY = Mathf.Abs(child.transform.position.z - actualPosition.y);
			if(differenceX < tolerance && differenceY < tolerance) {
				DiceBehavior behavior = child.GetComponent<DiceBehavior>();
				diceMenu.setSelectedDice(behavior);
				diceMenu.activate(behavior);
				break;
			}
		}
	}

	Vector2 translateTouchPoints(Vector3 fingerPos) {
		float ratioX = -.5f + (fingerPos.x / screenSize.x);
		float ratioY = -.5f + (fingerPos.y / screenSize.y);

		float actualX = ratioX * bounds.x * 2;
		float actualY = ratioY * bounds.y * 2;
		return new Vector2 (actualX, actualY);
	}

	public void shakeAllDice(Vector3 jerk) {
		foreach (Transform child in transform) {
			child.gameObject.GetComponent<DiceBehavior>().shakeDie(jerk);
		}
	}

	public void addDice(string diceName) {
		GameObject newDice = (GameObject)Resources.Load(diceName);
		
		// Create an instance of the prefab
		GameObject instance = (GameObject)GameObject.Instantiate(newDice);
		instance.transform.position = new Vector3(0,5,0);
		instance.transform.parent = this.transform;
		instance.transform.tag = diceName;
		instance.transform.localScale = new Vector3 (diceScale, diceScale, diceScale);
	}

	public void removeDice(string diceName) {
		GameObject diceToDestroy = GameObject.FindGameObjectWithTag(diceName);
		Destroy(diceToDestroy);
	}

	public void updateDiceScale(float newDiceScale) {
		this.diceScale = newDiceScale;
		foreach (Transform child in transform)
		{
			child.transform.localScale = new Vector3(diceScale, diceScale, diceScale);
		}
	}
}
