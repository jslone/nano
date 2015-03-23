using UnityEngine;
using System.Collections;

public class WheelDriver : MonoBehaviour {
	public Rigidbody2D driver;
	public DirectionalSliderJoint2D reciever;
	public float Scale;
	private float Offset;

	// Use this for initialization
	void Start () {
		Offset = reciever.joint.motor.motorSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		JointMotor2D motor = reciever.joint.motor;
		motor.motorSpeed = Scale * driver.angularVelocity + Offset;
		reciever.joint.motor = motor;
	}
}
