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

	private Animator animator;

	// default levels
	private static int[] defaultLevels = {0,1};
	private static GameObject[] disabledWorld;

	private Audio audio;

	// Use this for initialization
	void Start () {
		if (currentCharacter == Character.PICO) {
			Player = Instantiate<GameObject>(PicoPrefab).GetComponent<PlayerController>();
		} else {
			Player = GameObject.Find(currentCharacter.ToString()).GetComponent<PlayerController>();
			animator = Player.GetComponent<Animator>();
		}

		audio = Audio.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		// Otherwise, check for zoom button
		if (Input.GetButtonDown("ZoomIn")) {
			ZoomIn();
		}
		if (Input.GetButtonDown("ZoomOut")) {
			ZoomOut();
		}
	}

	void SwapLevel(Character current, Character next)
	{
		// disable micros world
		GameObject[] currentWorld = GameObject.FindGameObjectsWithTag(current.ToString());
		foreach(GameObject g in currentWorld)
		{
			g.SetActive(false);
		}

		// if nano's world can't be found, load it
		if (disabledWorld == null || disabledWorld.Length == 0)
		{
			Application.LoadLevelAdditive(defaultLevels[(int)next]);
		}
		// otherwise activate nano's world
		else
		{
			foreach (GameObject g in disabledWorld)
			{
				g.SetActive(true);
			}
		}

		disabledWorld = currentWorld;
	}
	
	public void ZoomIn() {
		switch(currentCharacter) {
		case Character.MICRO:
			SwapLevel(Character.MICRO, Character.NANO);
			break;

		case Character.NANO:
			// release the pico
			animator.SetTrigger("deploy");
			Player = Instantiate<GameObject>(PicoPrefab).GetComponent<PlayerController>();
			currentCharacter = Character.PICO;
			audio.PlayPico();
			break;

		default:
			return;
		}
	}
	
	public void ZoomOut() {
		switch(currentCharacter) {
		case Character.NANO:
			//SwapLevel(Character.NANO, Character.MICRO);
			break;
		case Character.PICO:
			// switch to nano
			PicoDeath death = Player.GetComponent<PicoDeath>();
			if(!death.dead) {
				death.Die();
			} else {
				Destroy(Player.gameObject);
				Player = GameObject.Find(Character.NANO.ToString()).GetComponent<PlayerController>();
				animator.SetTrigger("retract");
				currentCharacter = Character.NANO;
			}
			audio.PlayNano();
			break;

		default:
			return;
		}
	}
	
	
}
