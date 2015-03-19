using UnityEngine;
using System.Collections;

public class GearTrigger : Trigger {
	public WheelJoint2D[] Gears;

	public override bool On
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

    public override void Flip()
    {
        foreach(WheelJoint2D gear in Gears)
        {
            gear.useMotor = !gear.useMotor;
        }
    }
}
