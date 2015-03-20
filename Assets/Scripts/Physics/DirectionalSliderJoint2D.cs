using UnityEngine;
using System.Collections;

public class DirectionalSliderJoint2D : MonoBehaviour {
	public SliderJoint2D joint;
	public bool useMotor
	{
		get
		{
			return neg ^ joint.motor.motorSpeed < 0;
		}
		set
		{
			if(value != useMotor) {
				JointMotor2D m = joint.motor;
				m.motorSpeed *= -1;
				joint.motor = m;
			}
		}
	}
	bool neg;

	// Use this for initialization
	void Start () {
		neg = joint.motor.motorSpeed < 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
