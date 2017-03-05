using UnityEngine.UI;

public class Counter {
	private Text text;
	private string color;
	
	public Counter(Text counterText, string textColor) {
		text = counterText;
		color = textColor;
		text.color = Dictionaries.colorDictionary[textColor];
	}

	public Counter(Counter other) {
		text = other.getText ();
		color = other.getColor ();
		text.color = Dictionaries.colorDictionary [other.getColor()];
	}
	
	public void setTextString(string newString) {
		text.text = newString;
	}

	public void activate() {
		text.gameObject.SetActive (true);
	}

	public void deactivate() {
		text.gameObject.SetActive (false);
	}

	public string getColor() {
		return color;
	}

	public Text getText() {
		return text;
	}

	public bool isActive() {
		return text.IsActive ();
	}
}
