using UnityEngine;
using System.Collections;

public class DoorTrigger : Trigger {
	public SliderJoint2D Door;
	
	public bool isOpen
	{ 
		get { return Door.useMotor; }
		set { Door.useMotor = value; }
	}
	
	public override void OnTrigger ()
	{
		isOpen = !isOpen;
	}
}
