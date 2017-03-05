using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DiceOptionsBehavior : MonoBehaviour {
	private DiceBehavior selectedDice;
	private Toggle colorCountToggle;
	private InputField modifier;
	private Dictionary<string, Button> colorButtonDictionary;
	private InputField actionNameText;

	// Use this for initialization
	void Start () {
		colorCountToggle = this.transform.FindChild("Color_Count_Toggle").GetComponent<Toggle>();
		modifier = this.transform.FindChild("InputField").GetComponent<InputField>();
		actionNameText = this.transform.FindChild ("ActionName").GetComponent<InputField> ();
		colorButtonDictionary = new Dictionary<string, Button> {
			{"black", transform.FindChild("black").GetComponent<Button>()},
			{"blue", transform.FindChild("blue").GetComponent<Button>()},
			{"cyan", transform.FindChild("cyan").GetComponent<Button>()},
			{"green", transform.FindChild("green").GetComponent<Button>()},
			{"orange", transform.FindChild("orange").GetComponent<Button>()},
			{"pink", transform.FindChild("pink").GetComponent<Button>()},
			{"red", transform.FindChild("red").GetComponent<Button>()},
			{"scarlet", transform.FindChild("scarlet").GetComponent<Button>()},
			{"white", transform.FindChild("white").GetComponent<Button>()},
			{"yellow", transform.FindChild("yellow").GetComponent<Button>()}
		};
	}

	public void setDiceColor(string newColor) {
		colorButtonDictionary [selectedDice.getColor ()].interactable = true;
		selectedDice.setTexture(newColor);
		colorButtonDictionary [newColor].interactable = false;
		setActionNameText ();
	}

	public void setDiceModifier() {
		int temp = 0;
		if(selectedDice != null && int.TryParse(modifier.text, out temp)) {
			selectedDice.setModifier(temp);
		}
	}

	public void setSelectedDice(DiceBehavior newSelected) {
		selectedDice = newSelected;
	}

	public void activate(DiceBehavior behavior) {
		selectedDice = behavior;

		this.gameObject.SetActive(true);

		colorCountToggle.isOn = selectedDice.shouldColorCount ();
		modifier.text = selectedDice.getModifier ().ToString ();
		colorButtonDictionary [selectedDice.getColor ()].interactable = false;

		setActionNameText ();
	}

	private void setActionNameText() {
		string actionName = Dictionaries.actionDictionary[selectedDice.getColor ()];
		if(actionName != null && actionName.Trim().Length != 0) {
			actionNameText.text = actionName;
		} else {
			actionNameText.text = "";
		}
	}

	public void deactivate() {
		if(selectedDice != null) {
			int number;
			selectedDice.setModifier (int.TryParse (modifier.text, out number) ? number : 0);
			selectedDice.setShouldColorCount (colorCountToggle.isOn);
			colorButtonDictionary [selectedDice.getColor ()].interactable = true;
		}
		this.gameObject.SetActive(false);
	}

	public bool isActive() {
		return this.gameObject.activeSelf;
	}

	public void updateActionName() {
		Dictionaries.actionDictionary.Remove (selectedDice.getColor ());
		Dictionaries.actionDictionary.Add (selectedDice.getColor (), actionNameText.text);
	}
}
