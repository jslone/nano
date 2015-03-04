using UnityEngine;
using System.Collections;

public class TogglePlayer : MonoBehaviour {
	public InputController inputController;
	public CameraController cameraController;
	public PlayerController[] players;
	
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
	private static int zoomLevel = 0;
	
	// Use this for initialization
	void Start () {

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
		switch(zoomLevel) {
		case 0:
			// load nano's world
			int level = PlayerPrefs.GetInt("nano.level",nanoLevelDefault);
			Application.LoadLevel(level);
			break;
		case 1:
			// switch to pico
			break;
		default:
			return;
		}
		zoomLevel++;
	}
	
	public void ZoomOut() {
		switch(zoomLevel) {
		case 1:
			// load micro's world
			int level = PlayerPrefs.GetInt("micro.level",microLevelDefault);
			Application.LoadLevel(level);
			break;
		case 2:
			// switch to nano
			break;
		default:
			return;
		}
		zoomLevel--;
	}
	
	
	
	
}
