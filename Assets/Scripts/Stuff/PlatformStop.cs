using UnityEngine;
using System.Collections;

public class PlatformStop : MonoBehaviour {
	private SliderJoint2D slider;
	private float speed;

	private bool _onPlatform = false;
	private bool onPlatform
	{
		get { return _onPlatform; }
		set
		{
			if(!_onPlatform && value) {
				JointMotor2D motor = slider.motor;
				motor.motorSpeed -= speed;
				slider.motor = motor;
				Debug.Log(speed);
				Debug.Log(slider.motor.motorSpeed);
			}
			if(_onPlatform & !value) {
				JointMotor2D motor = slider.motor;
				motor.motorSpeed += speed;
				slider.motor = motor;
				Debug.Log(speed);
				Debug.Log(slider.motor.motorSpeed);
			}
			_onPlatform = value;
		}
	}
	private bool onPlatformLastFrame = false;

	// Use this for initialization
	void Start () {
		slider = GetComponent<SliderJoint2D>();
		speed = slider.motor.motorSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(onPlatform) {
			if(!onPlatformLastFrame) {
				onPlatform = false;
			}
			onPlatformLastFrame = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == Character.NANO.ToString()) {
			onPlatform = true;
			onPlatformLastFrame = true;
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		if(col.gameObject.tag == Character.NANO.ToString()) {
			onPlatform = true;
			onPlatformLastFrame = true;
		}
	}
}
