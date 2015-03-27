using UnityEngine;
using System.Collections;

public class ActivateGear : MonoBehaviour {
	
	public float MotorSpeed = 0f;
	public int unlockLevel;

	private bool _isLocked = true;
	public bool isLocked
	{
		get { return _isLocked; }
		set
		{
			if(value != _isLocked) {
				JointMotor2D motor = GetComponent<WheelJoint2D>().motor;
				motor.motorSpeed = value ? 0f : MotorSpeed;
				GetComponent<WheelJoint2D>().motor = motor;
				_isLocked = value;
			}
		}
	}

	void Start()
	{
	}
	
	void Update ()
	{
		isLocked = unlockLevel > GameState.level;
	}
}
