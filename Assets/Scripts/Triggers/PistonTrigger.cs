using UnityEngine;
using System.Collections;

public class PistonTrigger : Trigger {
	public PistonJoint2D[] Pistons;
    public bool isOscillating
    {
        get
        {
            bool on = false;
            foreach (PistonJoint2D piston in Pistons)
            {
                on |= piston.useMotor;
            }
            return on;
        }
        set
        {
            foreach (PistonJoint2D piston in Pistons)
            {
                piston.useMotor = value;
            }
        }
    }

    public void Flip()
    {
        foreach (PistonJoint2D piston in Pistons)
        {
            piston.useMotor = !piston.useMotor;
        }
    }

    public override void OnTrigger()
    {
        Flip();
    }
}
