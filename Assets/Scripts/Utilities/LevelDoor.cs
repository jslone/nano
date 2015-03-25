﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelDoor : MonoBehaviour {
	public string levelName;
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	public Image guiImage;
	
	public bool sceneStarting = true;      // Whether or not the scene is still fading in.
	public bool sceneEnding = false;


	void Start()
	{
		guiImage.color = Color.black;
	}
	
	void Update ()
	{
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();

		if(sceneEnding)
			EndScene();
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
	
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(guiImage.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			guiImage.color = Color.clear;
			guiImage.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		guiImage.enabled = true;
		sceneEnding = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if(guiImage.color.a >= 0.95f)
			// ... reload the level.
			Application.LoadLevel(levelName);
	}
}