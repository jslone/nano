using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {
	public float Delay;
	new private SliderJoint2D slider;
	// Use this for initialization
	void Start () {
		Invoke ("BeginMove", Delay);
	}
	
	void BeginMove() {
		GetComponent<SliderJoint2D>().useMotor = true;
	}
}
