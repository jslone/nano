using UnityEngine;
using System.Collections;

public class PistonTrigger : Trigger {
	public PistonJoint2D Piston;
	public bool isOscillating
	{
		get { return Piston.useMotor; }
		set { Piston.useMotor = value; }
	}
	
	public override void OnTrigger ()
	{
		isOscillating = !isOscillating;
	}
}
