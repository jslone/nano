using UnityEngine;
using System.Collections;

public class PistonJoint2D : MonoBehaviour {
	public bool useMotor;
	public float Speed;
	public Vector3 Offset;
	
	private Vector3 pos;
	private float time = 0;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(useMotor) {
			time += Time.deltaTime;
			transform.position = pos + Offset * Mathf.PingPong(Speed * time, 1.0f);
		}
	}
}
