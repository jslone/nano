using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConveyerBelt : MonoBehaviour {
	public bool useMotor;
	public float Speed;
	private List<Rigidbody2D> stuffOnBelt;

	// Use this for initialization
	void Start () {
		stuffOnBelt = new List<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if(useMotor) {
			foreach(Rigidbody2D thing in stuffOnBelt) {
				thing.AddForce(Speed * transform.right);
			}
		}
		stuffOnBelt.Clear();
	}

	void OnCollisionEnter2D(Collision2D col) {
		stuffOnBelt.Add(col.rigidbody);
	}

	void OnCollisionStay2D(Collision2D col) {
		stuffOnBelt.Add(col.rigidbody);
	}

}
