using UnityEngine;
using System.Collections;

public class DiceBehavior : MonoBehaviour {
	// Dice Texture Maps
	private readonly string TEXTURE_PATH = "Textures/dice_maps/";

	
	// Other Variables
	private float height, width;
	private int modifier;
	private string color;
	private bool colorCountThisDice;

	//AudioClip audioClip;
	private AudioSource audioSource;
	public AudioClip dice;


	// Use this for initialization
	void Start () {
		// set the physics variables
		//Physics.gravity = new Vector3 (0f, -100.0f, 0f);
		rigidbody.maxAngularVelocity = 300f;

		// set the default texture
		if (this.renderer.material.mainTexture == null) {
			this.color = "white";
			setTexture("white");
		}

		// set camera bounds
		width = Camera.main.orthographicSize * .85f;
		height = width * Camera.main.aspect;

		// set the default modifier
		modifier = 0;

		// and the color count
		colorCountThisDice = true;

		audioSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		boundDie ();
	}

	void OnCollisionEnter(Collision collision) {
		// play sound
		audioSource.PlayOneShot (dice, 1000f);
	}

	public void setTexture(string newColor) {
		Texture newTexture = (Texture)Resources.Load (TEXTURE_PATH + newColor);
		this.renderer.material.SetTexture ("_MainTex", newTexture);
		this.color = newColor;
	}

	/// <summary>
	/// Jerk is a measure of the change in acceleration.  It is assumed that the dice container
	/// will calculate this in each frame.  When it exceeds a certain threashold, it will 
	/// pass the 3D jerk vector into this function to shake the dice.
	/// </summary>
	public void shakeDie(Vector3 jerk) {
		// force
		float manhattanVelocity = rigidbody.velocity.x + rigidbody.velocity.y + rigidbody.velocity.z;
		float multiplier = 30000f / Mathf.Max(manhattanVelocity, 1f);
		float x = jerk.x * multiplier;
		float y = jerk.y * multiplier;
		float z = jerk.z * multiplier;
		this.rigidbody.AddForce(new Vector3(x, y, z));

		float torque = 1000.0f;
		float a = Random.Range(-(jerk.x * torque), (jerk.x * torque));
		float b = Random.Range(-(jerk.y * torque), (jerk.y * torque));
		float c = Random.Range(-(jerk.z * torque), (jerk.z * torque));
		this.rigidbody.AddTorque(a,b,c, ForceMode.Force);
	}

	private void boundDie() {
		Vector3 newVelocity = this.rigidbody.velocity;
		Vector3 position = this.transform.position;
		Vector3 scale = this.transform.localScale;

		float X_MAX = 17.5f - scale.x;
		float Y_MAX = 40f;
		float Z_MAX = 32f - scale.z;

		float X_MIN = -X_MAX;
		float Y_MIN = -1f + scale.y;
		float Z_MIN = -Z_MAX;

		/*if(position.x > X_MAX) {
			position.x = X_MAX;
			if (newVelocity.x > 0) {
				newVelocity.x *= -.8f;
			}
		} else if (position.x < X_MIN) {
			position.x = X_MIN;
			if(newVelocity.x < 0) {
				newVelocity.x *= -.8f;
			}
		}*/
		
		if (position.y > Y_MAX){
			position.y = Y_MAX;
			if (newVelocity.y > 0) {
				newVelocity.y *= -.8f;
			}
		} else if (position.y < Y_MIN) {
			position.y = Y_MIN;
			if (newVelocity.y < 0) {
				newVelocity.y *= -.8f;
			}
		}
		
		/*if(position.z > Z_MAX) {
			position.z = Z_MAX;
			if(newVelocity.z > 0) {
				newVelocity.z *= -.8f;
			}
		} else if (position.z < Z_MIN) {
			position.z = Z_MIN;
			if(newVelocity.z < 0) {
				newVelocity.z *= -.8f;
			}
		}*/

		this.rigidbody.velocity = newVelocity;
		this.transform.position = position;
	}

	public void setModifier(int newValue) {
		this.modifier = newValue;
	}

	public string getColor() {
		return this.color;
	}

	public bool shouldColorCount() {
		return colorCountThisDice;
	}

	public void setShouldColorCount(bool newValue) {
		colorCountThisDice = newValue;
	}

	public int getModifier() {
		return modifier;
	}

	// This can probably be optomized
	public int getValueWithModifier() {
		float x = this.transform.eulerAngles.x;
		float z = this.transform.eulerAngles.z;
		Vector2 bestKey = new Vector2(100000f, 500f);
		float bestDifference = float.MaxValue;
		
		foreach (Vector2 angles in Dictionaries.diceDictionaryDictionary[this.tag].Keys) {
			float thisDifference = Mathf.Min(Mathf.Abs(x - angles.x), Mathf.Abs(x - angles.x + 360), Mathf.Abs(x - angles.x - 360)) +
				Mathf.Min(Mathf.Abs(z - angles.y), Mathf.Abs(z - angles.y + 360), Mathf.Abs(z - angles.y - 360));
			
			if(thisDifference < bestDifference) {
				bestKey = angles;
				bestDifference = thisDifference;
			}
		}
		
		return (bestKey.x == 100000 ? 0 : Dictionaries.diceDictionaryDictionary[this.tag][bestKey]) + getModifier();
	}
}
