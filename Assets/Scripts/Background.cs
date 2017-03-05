using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	private readonly string TEXTURE_PATH = "Textures/backgrounds/";

	public void setBackground(string newBackground) {
		Texture newTexture = (Texture)Resources.Load (TEXTURE_PATH + newBackground);
		this.renderer.material.SetTexture ("_MainTex", newTexture);
	}
}
