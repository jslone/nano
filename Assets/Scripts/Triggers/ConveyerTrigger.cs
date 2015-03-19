using UnityEngine;
using System.Collections;

public class ConveyerTrigger : Trigger {
	public ConveyerBelt[] Conveyers;

	public override bool On
	{
		get
		{
			bool on = false;
			foreach (ConveyerBelt conveyer in Conveyers)
			{
				on |= conveyer.useMotor;
			}
			return on;
		}
		set
		{
			foreach (ConveyerBelt conveyer in Conveyers)
			{
				conveyer.useMotor = value;
			}
		}
	}
	
	public override void Flip()
	{
		foreach (ConveyerBelt conveyer in Conveyers)
		{
			conveyer.useMotor = !conveyer.useMotor;
		}
	}
}
