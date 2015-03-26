using UnityEngine;
using System.Collections;

public class LavaDie : MonoBehaviour {

	public float sinkRate = 0.5f;
	public float sinkTime = 4f;
	public float fadeRate = 0f;

	private bool sinking = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (sinking) {
			Vector3 position = transform.position;
			position.y -= sinkRate * Time.deltaTime;
			transform.position = position;

			Color color = GetComponent<SpriteRenderer>().color;
			color.a -= fadeRate * Time.deltaTime;
			GetComponent<SpriteRenderer>().color = color;
		}

	}

	void StopSinking () {
		GetComponent<DeathController>().Die();
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(!sinking && col.collider.tag == "Lava") {
			sinking = true;
			GetComponent<Rigidbody2D>().isKinematic = true;
			Invoke("StopSinking", sinkTime);
		}
	}
}
