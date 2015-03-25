using UnityEngine;
using System.Collections;

public class WheelDoorDriver : MonoBehaviour {
	public Rigidbody2D driver;
	public DirectionalSliderJoint2D[] reciever;
	public float Scale;
	private float lastAngularVelocity = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < reciever.Length; i++) {
			JointMotor2D motor = reciever[i].joint.motor;
			motor.motorSpeed += Scale * (driver.angularVelocity - lastAngularVelocity);
			reciever[i].joint.motor = motor;
		}
		lastAngularVelocity = driver.angularVelocity;
	}
}
