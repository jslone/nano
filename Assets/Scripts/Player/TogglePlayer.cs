using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	private static int[] defaultLevels = {0,1};
	private static List<GameObject>[] worlds = new List<GameObject>[] {
		new List<GameObject>(),
		new List<GameObject>()
	};

	// for zooming in and out of Nano's world
	public float zoomSpeed = 5f;
	public float minZoom = 2f;
	public float maxZoom = 7f;
	public float zoomOffset = -4f;

	private bool zoomedToPico = false;
	private bool zooming = false;
	
	// Use this for initialization
	void Start () {
		if (currentCharacter == Character.PICO)
		{
			Player = Instantiate<GameObject>(PicoPrefab).GetComponent<PlayerController>();
		}
		else
		{
			Player = GameObject.Find(currentCharacter.ToString()).GetComponent<PlayerController>();
			CacheWorld(currentCharacter);
		}
	}
	
	// Update is called once per frame
	void Update () {

		// Zoom in or out by adjusting camera size
		if (zooming) {
			Camera _camera = GetComponent<Camera>();
			float newSize;
			float newOffset;

			if (zoomedToPico) {
				newSize = _camera.orthographicSize - Time.deltaTime * zoomSpeed;
			} else {
				newSize = _camera.orthographicSize + Time.deltaTime * zoomSpeed;
			}

			if (newSize >= maxZoom) {
				_camera.orthographicSize = maxZoom;
				cameraController.offset.y -= zoomOffset;
				zooming = false;
			} else if (newSize <= minZoom) {
				_camera.orthographicSize = minZoom;
				zooming = false;
			} else {
				_camera.orthographicSize = newSize;
			}
		} else {
			// Otherwise, check for zoom button
			if (Input.GetButtonDown("ZoomIn")) {
				ZoomIn();
			}
			if (Input.GetButtonDown("ZoomOut")) {
				ZoomOut();
			}
		}
	}

	void CacheWorld(Character current)
	{
		GameObject[] world = GameObject.FindGameObjectsWithTag(currentCharacter.ToString());
		foreach (GameObject g in world)
		{
			worlds[(int)currentCharacter].Add(g);
		}
	}

	void SwapLevel(Character current, Character next)
	{
		// disable micros world
		foreach(GameObject g in worlds[(int)current])
		{
			g.SetActive(false);
		}

		// if nano's world can't be found, load it
		if (worlds[(int)next].Count == 0)
		{
			Application.LoadLevelAdditive(defaultLevels[(int)next]);
			CacheWorld(next);
		}
		
		// otherwise activate nano's world
		else
		{
			foreach (GameObject g in worlds[(int)next])
			{
				g.SetActive(true);
			}
		}
	}
	
	public void ZoomIn() {
		if (zooming) {
			return;
		}

		switch(currentCharacter) {
		case Character.MICRO:
			SwapLevel(Character.MICRO, Character.NANO);
			break;

		case Character.NANO:
			// release the pico
			Player = Instantiate<GameObject>(PicoPrefab).GetComponent<PlayerController>();
			currentCharacter = Character.PICO;
			cameraController.offset.y += zoomOffset;
			zoomedToPico = true;
			zooming = true;
			break;

		default:
			return;
		}
	}
	
	public void ZoomOut() {
		if (zooming) {
			return;
		}

		switch(currentCharacter) {
		case Character.NANO:
			SwapLevel(Character.NANO, Character.MICRO);
			break;

		case Character.PICO:
			// switch to nano
			Destroy(Player.gameObject);
			Player = GameObject.Find(Character.NANO.ToString()).GetComponent<PlayerController>();
			currentCharacter = Character.NANO;
			zoomedToPico = false;
			zooming = true;
			break;

		default:
			return;
		}
	}
	
	
}
