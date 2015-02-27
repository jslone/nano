using UnityEngine;
using System.Collections;

public class TogglePlayer : MonoBehaviour {
	public InputController input;
	public CameraController cam;
	public PlayerController[] players;
	// Use this for initialization
	void Start () {
		input.player = players[0];
		cam.player = input.player;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)) input.player = players[0];
		if(Input.GetKeyDown(KeyCode.Alpha2)) input.player = players[1];
		if(Input.GetKeyDown(KeyCode.Alpha3)) input.player = players[2];
		cam.player = input.player;
	}
}
