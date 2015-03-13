using UnityEngine;
using System.Collections;

public class DoorTrigger : Trigger {
	public SliderJoint2D[] Doors;
	
	public bool isOpen
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

    public void Flip()
    {
        foreach(SliderJoint2D door in Doors)
        {
            door.useMotor = !door.useMotor;
        }
    }
	
	public override void OnTrigger ()
	{
        Flip();
	}
}
