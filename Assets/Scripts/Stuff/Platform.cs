using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class Platform : MonoBehaviour {
	private bool touchedLastFrame = false;
	new private Collider2D collider2D;


	void Start() {
		collider2D = GetComponent<Collider2D>();
	}

	void FixedUpdate() {
		if(!touchedLastFrame) {
			collider2D.isTrigger = true;
		} else {
			touchedLastFrame = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.layer == LayerMask.NameToLayer("PlayerFeet")) {
			if(other.transform.parent.GetComponent<Rigidbody2D>().velocity.y < 0 &&
			   other.transform.position.y > transform.position.y) {
				touchedLastFrame = true;
				collider2D.isTrigger = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		touchedLastFrame = true;
		collider2D.isTrigger = false;
	}

	void OnCollisionStay2D(Collision2D other) {
		touchedLastFrame = true;
		collider2D.isTrigger = false;
	}
}
