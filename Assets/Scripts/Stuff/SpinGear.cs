using UnityEngine;
using System.Collections;

public class SpinGear : MonoBehaviour {
	public WheelJoint2D wheel;
	public PlayerController player;
	public float Scale;
	public Vector3 Offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player) {
			player.transform.position = transform.position + Vector3.Scale(transform.lossyScale,Offset);

			JointMotor2D motor = wheel.motor;

			motor.motorSpeed = Scale * player.GetComponent<Rigidbody2D>().velocity.x;

			wheel.motor = motor;
		} else {
			JointMotor2D motor = wheel.motor;

			motor.motorSpeed = 0;

			wheel.motor = motor;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.name);
		if(other.tag == Character.PICO.ToString()) {
			player = other.GetComponent<PlayerController>();
		}
	}
}
