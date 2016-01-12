using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {
	public float Delay;
	private SliderJoint2D slider;

	// Use this for initialization
	void Start () {
		slider = GetComponent<SliderJoint2D>();
		Invoke("BeginMove", Delay);
	}
	
	void BeginMove() {
		slider.useMotor = true;
	}
}
