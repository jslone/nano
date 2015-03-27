using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelDoor : MonoBehaviour {
	public string levelName;
	public float fadeSpeed = 2.0f;          // Speed that the screen fades to and from black.
	public int unlockLevel = 0;
	public Image guiImage;
	public Sprite lockedDoor;
	public Sprite unlockedDoor;
	
	public bool sceneStarting = true;      // Whether or not the scene is still fading in.
	public bool sceneEnding = false;
	public static bool lastSceneWasCutscene = false;
	public static int door;

	public bool isSpecial;
	public static string lastSpecialDoor;

	private bool _isLocked = false;
	public bool isLocked
	{
		get { return _isLocked; }
		set
		{
			if(value != _isLocked) {
				GetComponent<SpriteRenderer>().sprite = value ? lockedDoor : unlockedDoor;
				_isLocked = value;
			}
		}
	}

	void Start()
	{
		guiImage.color = Color.black;
		if(isSpecial && lastSpecialDoor == name) {
			Transform player = GameObject.Find(Character.NANO.ToString()).transform;
			player.position = new Vector3(transform.position.x,transform.position.y,player.position.z);
		}
	}
	
	void Update ()
	{
		isLocked = unlockLevel > GameState.level;

		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();

		else if(sceneEnding)
			EndScene();
	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		if(!lastSceneWasCutscene) {
			guiImage.color = Color.Lerp(guiImage.color, Color.clear, fadeSpeed * Time.deltaTime);
		} else {
			guiImage.color = Color.clear;
		}
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
		if(guiImage.color.a >= 0.95f) {
			// ... reload the level.
			lastSceneWasCutscene = false;
			if(isSpecial) {
				lastSpecialDoor = name;
			}
			Application.LoadLevel(levelName);

		}
	}
}
