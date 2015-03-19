using UnityEngine;
using System.Collections;

public class DoorTrigger : Trigger {
	public SliderJoint2D[] Doors;
	
	public override bool On
	{ 
		get
        {
            bool on = false;
            foreach (SliderJoint2D door in Doors)
            {
                on |= door.useMotor;
            }
            return on;
        }
        set
        {
            foreach (SliderJoint2D door in Doors)
            {
                door.useMotor = value;
            }
        }
	}

    public override void Flip()
    {
        foreach(SliderJoint2D door in Doors)
        {
            door.useMotor = !door.useMotor;
        }
    }
}
