using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class Apendage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "MICRO") {
			MicroLimbs.Limbs++;
			Destroy(gameObject);
		}
	}
}
