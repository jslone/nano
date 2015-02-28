using UnityEngine;
using System.Collections;

public class GearTrigger : Trigger {
	public WheelJoint2D Gear;
	public float Speed;
	public bool isRotating
	{ 
		get { return Gear.useMotor; }
		set { Gear.useMotor = value; }
	}
	
	public override void OnTrigger ()
	{
		isRotating = !isRotating;
	}
}
