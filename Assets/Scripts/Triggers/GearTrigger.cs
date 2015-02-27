using UnityEngine;
using System.Collections;

public class GearTrigger : Trigger {
	public Rigidbody2D Gear;
	public float Speed;
	public bool isRotating;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isRotating) {
			Gear.AddTorque(Speed,ForceMode2D.Impulse);
		}
	}
	
	public override void OnTrigger ()
	{
		isRotating = !isRotating;
	}
}
