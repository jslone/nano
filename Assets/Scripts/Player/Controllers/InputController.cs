using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	public PlayerController _player;
	public PlayerController player { 
		get { return _player; }
		set
		{
			if(_player) {
				_player.vInput = Vector2.zero;
			}
			_player = value;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player.vInput.x = Input.GetAxis("Horizontal");
		player.vInput.y = Input.GetAxis("Vertical");
		if(Input.GetButtonDown("Action")) {
			player.DoAction();
			player.UseDoor();
		}
	}
}
