using UnityEngine;
using System.Collections;

public class GearTrigger : Trigger {
	public WheelJoint2D[] Gears;
	public bool isRotating
	{ 
		get
        {
            bool on = false;
            foreach(WheelJoint2D gear in Gears)
            {
                on |= gear.useMotor;
            }
            return on;
        }
		set
        {
            foreach(WheelJoint2D gear in Gears)
            {
                gear.useMotor = value;
            }
        }
	}

    public void Flip()
    {
        foreach(WheelJoint2D gear in Gears)
        {
            gear.useMotor = !gear.useMotor;
        }
    }
	
	public override void OnTrigger ()
	{
        Flip();
	}
}
