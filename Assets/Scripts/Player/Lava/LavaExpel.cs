using UnityEngine;
using System.Collections;

public class LavaExpel : MonoBehaviour {
	public float Speed;

	private PlayerController player;
	new private Rigidbody2D rigidbody2D;

	private Vector3 lastSafe;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerController>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.isGrounded) {
			lastSafe = transform.position;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.collider.tag == "Lava") {
			Vector3 dir = lastSafe - transform.position;
			rigidbody2D.AddForce(Speed/2 * (dir.normalized + Vector3.up));
		}
	}
}
