using UnityEngine;
using System.Collections;

public class DirectionalSliderTrigger : Trigger {
	public DirectionalSliderJoint2D[] Sliders;
	
	public override bool On
	{ 
		get
        {
            bool on = false;
            foreach (DirectionalSliderJoint2D slider in Sliders)
            {
                on |= slider.useMotor;
            }
            return on;
        }
        set
        {
            foreach (DirectionalSliderJoint2D slider in Sliders)
            {
                slider.useMotor = value;
            }
        }
	}

    public override void Flip()
    {
        foreach(DirectionalSliderJoint2D slider in Sliders)
        {
            slider.useMotor = !slider.useMotor;
        }
    }
}
