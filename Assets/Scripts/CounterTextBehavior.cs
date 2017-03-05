using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CounterTextBehavior : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}

	public void increment() {
		int count = int.Parse(text.text);
		count++;
		text.text = count.ToString();
	}

	public void decrement() {
		int count = int.Parse(text.text);
		if (count > 0) {
			count--;
			text.text = count.ToString ();
		}
	}
}
