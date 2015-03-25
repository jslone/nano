using UnityEngine;
using System.Collections;

public class DoorWheelDriver : MonoBehaviour {
	public Rigidbody2D driver;
	public WheelJoint2D[] reciever;
	public float Scale;
	private float[] Offset;
	
	// Use this for initialization
	void Start () {
		Offset = new float[reciever.Length];
		for(int i = 0; i < reciever.Length; i++) {
			Offset[i] = reciever[i].motor.motorSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < reciever.Length; i++) {
			JointMotor2D motor = reciever[i].motor;
			motor.motorSpeed = Scale * driver.velocity.magnitude + Offset[i];
			reciever[i].motor = motor;
		}
	}
}
