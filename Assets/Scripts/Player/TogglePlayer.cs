using UnityEngine;
using System.Collections;

public class TogglePlayer : MonoBehaviour {
	public GameObject PicoPrefab;

	public Character currentCharacter;

	// maintain current player
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

	public InputController inputController;
	public CameraController cameraController;

	// default levels
	private static int microLevelDefault = 0;
	private static int nanoLevelDefault = 1;
	
	// Use this for initialization
	void Start () {
		if(currentCharacter == Character.PICO) {
			Player = Instantiate<GameObject>(PicoPrefab).GetComponent<PlayerController>();
		} else {
			Player = GameObject.Find(currentCharacter.ToString()).GetComponent<PlayerController>();
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
			Player = Instantiate<GameObject>(PicoPrefab).GetComponent<PlayerController>();
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
			Destroy(Player.gameObject);
			Player = GameObject.Find(Character.NANO.ToString()).GetComponent<PlayerController>();
			break;
		default:
			return;
		}
		currentCharacter--;
	}
	
	

	
}
