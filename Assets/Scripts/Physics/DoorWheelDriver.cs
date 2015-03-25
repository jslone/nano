using UnityEngine;
using System.Collections;

public class DoorWheelDriver : MonoBehaviour {
	public Rigidbody2D driver;
	public WheelJoint2D[] reciever;
	public float Scale;
	private float lastVelocity = 0.0f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < reciever.Length; i++) {
			JointMotor2D motor = reciever[i].motor;
			motor.motorSpeed += Scale * (driver.velocity.magnitude - lastVelocity);
			reciever[i].motor = motor;
		}
		lastVelocity = driver.velocity.magnitude;
	}
}
