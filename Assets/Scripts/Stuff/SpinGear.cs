using UnityEngine;
using System.Collections;

public class SpinGear : MonoBehaviour {
	public WheelJoint2D wheel;
	public PlayerController player;
	public float Scale;
	public CameraData camData;
	public Vector3 Offset;
	public int setLevelOnActivate = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player) {
			player.transform.position = transform.position + Vector3.Scale(transform.lossyScale,Offset);
			JointMotor2D motor = wheel.motor;
			motor.motorSpeed = Scale * player.GetComponent<Rigidbody2D>().velocity.x;

			if (motor.motorSpeed != 0 && setLevelOnActivate > 0 && GameState.level < setLevelOnActivate) {
				GameState.SetLevel(setLevelOnActivate);
			}

			wheel.motor = motor;
		} else {
			JointMotor2D motor = wheel.motor;
			motor.motorSpeed = 0;
			wheel.motor = motor;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == Character.PICO.ToString()) {
			player = other.GetComponent<PlayerController>();
			player.canCollide = false;
			FindObjectOfType<CameraController>().playerCamera = camData;
		}
	}
}
