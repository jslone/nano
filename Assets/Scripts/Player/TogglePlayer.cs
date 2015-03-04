using UnityEngine;
using System.Collections;

public class TogglePlayer : MonoBehaviour {
	public InputController inputController;
	public CameraController cameraController;
	public Character currentCharacter;
	private PlayerController _player;
	public PlayerController Player
	{
		get { return _player; }
		set
		{
			_player = value;
			inputController.player = value;
			cameraController.player = value;
		}
	}
	
	private static int microLevelDefault = 0;
	private static int nanoLevelDefault = 1;
	
	// Use this for initialization
	void Start () {
		switch(currentCharacter) {
			case Character.MICRO:
				Player = GameObject.Find("Micro").GetComponent<PlayerController>();
				break;
			case Character.NANO:
				Player = GameObject.Find("Nano").GetComponent<PlayerController>();
				break;
			case Character.PICO:
				Player = GameObject.Find("Pico").GetComponent<PlayerController>();
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("ZoomIn")) {
			ZoomIn();
		}
		if(Input.GetButtonDown("ZoomOut")) {
			ZoomOut();
		}
	}
	
	public void ZoomIn() {
		switch(currentCharacter) {
		case Character.MICRO:
			// load nano's world
			int level = PlayerPrefs.GetInt("nano.level",nanoLevelDefault);
			Application.LoadLevel(level);
			break;
		case Character.NANO:
			// switch to pico
			Player = GameObject.Find("Pico").GetComponent<PlayerController>();
			break;
		default:
			return;
		}
		currentCharacter++;
	}
	
	public void ZoomOut() {
		switch(currentCharacter) {
		case Character.NANO:
			// load micro's world
			int level = PlayerPrefs.GetInt("micro.level",microLevelDefault);
			Application.LoadLevel(level);
			break;
		case Character.PICO:
			// switch to nano
			Player = GameObject.Find("Nano").GetComponent<PlayerController>();
			break;
		default:
			return;
		}
		currentCharacter--;
	}
	
	

	
}
