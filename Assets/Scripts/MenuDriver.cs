using UnityEngine;
using System.Collections;

public class MenuDriver : MonoBehaviour {
	GameObject optionsMenu, backgroundMenu;
	DiceOptionsBehavior diceMenu;

	void Start () {
		optionsMenu = this.transform.FindChild ("User_Options").gameObject;
		diceMenu = this.transform.FindChild ("Dice_Options").GetComponent<DiceOptionsBehavior>();
		backgroundMenu = this.transform.FindChild ("Background_Options").gameObject;

		optionsMenu.SetActive (false);
		diceMenu.deactivate ();
		backgroundMenu.SetActive (false);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(anyMenuIsActive()) {
				clickTopLeftButton();
			} else {
				Application.Quit();
			}
		}
	}

	public void clickTopLeftButton() {
		if (optionsMenu.activeSelf) {
			optionsMenu.SetActive(false);
		} 
		else if(diceMenu.isActive()) {
			diceMenu.deactivate();
		}
		else if(backgroundMenu.activeSelf) {
			backgroundMenu.SetActive(false);
		}
		else {
			optionsMenu.SetActive(true);
		}
	}

	private bool anyMenuIsActive() {
		return optionsMenu.activeSelf || diceMenu.isActive() || backgroundMenu.activeSelf;
	}
}
