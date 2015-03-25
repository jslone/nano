using UnityEngine;
using System.Collections;

public class LavaExpel : MonoBehaviour {
	public float T = 1;

	private PlayerController player;
	new private Rigidbody2D rigidbody2D;
	new private Collider2D collider2D;
	private float linearDrag;

	private Vector3 lastSafe;
	private Vector2 v;
	private Vector2 g;
	private bool Controlling = false;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerController>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		collider2D = GetComponent<Collider2D>();
		g = 0.2f * rigidbody2D.gravityScale * Physics2D.gravity;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		if(Controlling) {
			transform.position += (Vector3)v * Time.fixedDeltaTime;
			v += g * Time.fixedDeltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.collider.tag == "Lava") {
			Controlling = true;

			Vector3 target = lastSafe - transform.position;
			
			v = Vector2.zero;
			v.x = target.x / T;
			v.y = (target.y - (g.y * T * T) / 2) / T;

			if(v.x < 1f && v.x > -1f) {
				v.x = 1f * Mathf.Sign(v.x);
			}

			player.canMove = false;
			player.canCollide = false;
			rigidbody2D.isKinematic = true;

			Invoke("Restore",T);
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		if(col.collider.tag == "Safe") {
			lastSafe = transform.position;
		}
	}

	void Restore() {
		Controlling = false;
		player.canMove = true;
		player.canCollide = true;
		rigidbody2D.isKinematic = false;
	}
}
