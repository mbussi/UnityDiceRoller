using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class CounterContainerBehavior : MonoBehaviour {
	// Dice container object that lets us keep track of all the dice on the screen
	private GameObject diceContainer;

	// The array of literal text counters on the screen
	private Counter[] counters;

	private Counter globalCounter;
	private GameObject allCounterText;
	
	void Start () {
		diceContainer = GameObject.FindGameObjectWithTag ("dice_container");

		globalCounter = new Counter(this.transform.FindChild ("DiceCounter").FindChild ("Counter_Value").GetComponent<Text>(), "white");
		globalCounter.deactivate ();
		allCounterText = this.transform.FindChild ("DiceCounter").FindChild ("Counter_Text").gameObject;
		allCounterText.SetActive (false);

		GameObject[] counterTextsArray = GameObject.FindGameObjectsWithTag ("counter_text");

		counters = new Counter[counterTextsArray.Length];
		for (int i=0; i<counterTextsArray.Length; i++) {
			Text t = counterTextsArray[i].GetComponent<Text>();
			string c = Dictionaries.colorDictionary.Keys.ElementAt(i);
			counters[i] = new Counter(t, c);
		}

		driver ();
		InvokeRepeating ("driver", .3f, .3f);
	}

	public void toggleAllCounter() {
		allCounterText.SetActive (!allCounterText.activeSelf);
		if (globalCounter.isActive()) {
			globalCounter.deactivate();
		} else {
			globalCounter.activate();
		}
	}

	/// <summary>
	/// Step 1: Declare the variables
	/// Step 2: Populate the count values by color dictionary
	/// Step 3: Activate and Deactivate Counters as necessary
	/// Step 4: Re-order the counters as necessary
	/// </summary>
	private void driver() {
		// Step 1: Declare the variables
		var valuesByColor = new Dictionary<string, int> (); // step 2
		//Queue<Counter> inactiveQueue = new Queue<Counter> ();	// step 3

		//Step 2: Populate the count values by color dictionary
		foreach (Transform child in diceContainer.transform) {
			//get the die's behavior script
			DiceBehavior diceBehavior = child.GetComponent<DiceBehavior>();

			// get the die's value
			int diceValue = diceBehavior.getValueWithModifier();

			// hash the value into "all"
			int counterValue;
			if(valuesByColor.TryGetValue("all", out counterValue)) {
				valuesByColor.Remove("all");
			}
			valuesByColor.Add("all", counterValue + diceValue);

			// hash the value into its color if specified
			if(diceBehavior.shouldColorCount()) {
				int colorCounterValue;
				if(valuesByColor.TryGetValue(diceBehavior.getColor(), out colorCounterValue)) {
					valuesByColor.Remove(diceBehavior.getColor());
				}
				valuesByColor.Add(diceBehavior.getColor(), colorCounterValue + diceValue);
			}
		}

		if (valuesByColor.ContainsKey ("all")) {
			globalCounter.setTextString ("" + valuesByColor ["all"]);
		}

		// Step 3: Activate and Deactivate Counters as necessary.  Set the values of any active counters.
		foreach (Counter c in counters) {
			bool counterShouldBeActive = valuesByColor.ContainsKey(c.getColor());
			if(counterShouldBeActive) {
				c.activate();
				string actionName = Dictionaries.actionDictionary[c.getColor()];
				string actualValue = actionName != null && actionName.Trim().Length != 0 ? actionName : c.getColor();
				c.setTextString(actualValue + ": " + valuesByColor[c.getColor()]);
			}
			else if(!counterShouldBeActive) {
				c.deactivate();
			}
		}

		// Step 4: Re-order the counters as necessary
		/*for (int i=0; i < counters.Length; i++) {
			Counter c = counters[i];
			if(!c.isActive()) {
				inactiveQueue.Enqueue(c);
			}
			else if (inactiveQueue.Count > 0) {
				Counter thisCounter = inactiveQueue.Dequeue();
				Counter temp = new Counter(thisCounter);
				thisCounter = new Counter(c);
				c = temp;
				inactiveQueue.Enqueue(c);
			}
		}*/
	}
}
