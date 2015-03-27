using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LavaExpel : MonoBehaviour {
	public Image guiImage;
	public float fadeSpeed = 5.0f;
	private PlayerController player;
	new private Rigidbody2D rigidbody2D;
	private Vector3 lastSafe;

	private bool fading = false;
	private bool unfading = false;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerController>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		guiImage = FindObjectOfType<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(fading)
			Fading();

		if(unfading)
			Unfading();
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.collider.tag == "Lava") {

			player.canMove = false;
			player.canCollide = false;
			rigidbody2D.isKinematic = true;
			fading = true;

			TogglePlayer tp = FindObjectOfType<TogglePlayer>();
			if(tp.currentCharacter == Character.PICO) {
				tp.ZoomOut();
			}
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		if(col.collider.tag == "Safe") {
			lastSafe = transform.position;
		}
	}

	void Restore() {
		player.transform.position = lastSafe;
		player.canMove = true;
		player.canCollide = true;
		rigidbody2D.isKinematic = false;
	}

	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiImage.color = Color.Lerp(guiImage.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiImage.color = Color.Lerp(guiImage.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void Unfading ()
	{
		guiImage.enabled = true;
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(guiImage.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			guiImage.color = Color.clear;
			guiImage.enabled = false;
			
			// The scene is no longer starting.
			unfading = false;
		}
	}
	
	
	public void Fading ()
	{
		// Make sure the texture is enabled.
		guiImage.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if(guiImage.color.a >= 0.95f) {
			guiImage.color = Color.black;
			fading = false;
			unfading = true;
			Restore();
		}

	}
}
