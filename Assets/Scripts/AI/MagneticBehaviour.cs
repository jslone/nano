using UnityEngine;
using System.Collections;

public class MagneticBehaviour : MonoBehaviour {
	public float AttractSpeed;
	public float RepelSpeed;
	public float Cutoff;

	public GameObject nano;
	public GameObject pico;
	new private Rigidbody2D rigidbody2D;
	private TogglePlayer playerSelect;

	// Use this for initialization
	void Start () {
		nano = GameObject.Find(Character.NANO.ToString());
		rigidbody2D = GetComponent<Rigidbody2D>();
		playerSelect = FindObjectOfType<TogglePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerSelect.currentCharacter == Character.PICO) {
			pico = playerSelect.Player.gameObject;
		}
	}

	// Update called every physics update
	void FixedUpdate() {
		Vector2 dn = nano.transform.position - transform.position;
		float rn = dn.magnitude;
		dn.Normalize();

		// Repel
		Vector2 force = Vector2.zero;
		if(rn < Cutoff) {
			force -= (RepelSpeed / (rn * rn)) * dn;
		}

		// Attract
		if(pico != null) {
			Vector2 dp = pico.transform.position - transform.position;
			float rp = dp.magnitude;
			dp.Normalize();

			if(rp < Cutoff) {
				force += (AttractSpeed / (rp * rp)) * dp;
			}
		}

		force.y = 0;

		rigidbody2D.AddForce(force);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject == pico) {
			playerSelect.ZoomOut();
		}
	}
}
