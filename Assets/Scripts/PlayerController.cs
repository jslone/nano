using UnityEngine;
using System.Collections;

public enum ControlType {
	ARCADE,
	SMOOTH
};

public class PlayerController : MonoBehaviour {
	public ControlType Type;
	public float Speed;
	public bool canMove;
	
	private Vector2 delta;
	
	// Use this for initialization
	void Start () {
		delta = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove) {
			// get delta vector
			delta.x = Speed * Input.GetAxis("Horizontal");
			delta.y = 0;
		}
	}
	
	// Fixed update called every physics update
	void FixedUpdate() {
		switch (Type) {
		// use delta vector as velocity
		case ControlType.ARCADE:
			rigidbody2D.MovePosition(rigidbody2D.position + delta * Time.fixedDeltaTime);
			break;
		// use delta vector as acceleration
		case ControlType.SMOOTH:
			rigidbody2D.velocity += delta * Time.fixedDeltaTime;
			break;
		}
	}
}
