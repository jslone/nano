using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	public PlayerController player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player.Input.x = Input.GetAxis("Horizontal");
		player.Input.y = Input.GetAxis("Jump");
		if(Input.GetButtonDown("Action")) {
			player.DoAction();
		}
	}
}
