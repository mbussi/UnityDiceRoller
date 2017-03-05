using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour {
	float xMax, xMin;
	float yMax, yMin;


	public void Start() {
		float height = this.transform.GetComponent<RectTransform> ().rect.height;
		float width = this.transform.GetComponent<RectTransform> ().rect.width;

		xMax = this.transform.position.x + width / 2f;
		xMin = xMax - width;
		yMax = this.transform.position.y + height / 2f;
		yMin = yMax - height;
	}

	public bool isClicked(Vector2 position) {
		bool one = (xMin < position.x && position.x < xMax);
		bool two = (yMin < position.y && position.y < yMax);
		return (one && two);
	}
}
