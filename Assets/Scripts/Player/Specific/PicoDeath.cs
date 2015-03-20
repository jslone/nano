using UnityEngine;
using System.Collections;

public class PicoDeath : DeathController {
	public TogglePlayer toggle;
	public float TTL;
	public float TTD;
	private Vector3 deathPos;
	private float timeOfDeath;
	public bool dead;
	// Use this for initialization
	void Start () {
		toggle = FindObjectOfType<TogglePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		TTL -= Time.deltaTime;
		if(dead) {
			if(Time.time - timeOfDeath > TTD) {
				toggle.ZoomOut();
			} else {
				Vector3 to = transform.parent.position;
				transform.position = Vector3.Slerp(deathPos,to,(Time.time - timeOfDeath) / TTD);
			}
		} else if(TTL < 0) {
			Die();
		}
	}

	public override void Die ()
	{
		deathPos = transform.position;
		dead = true;
		timeOfDeath = Time.time;
		GetComponent<Collider2D>().enabled = false;
	}
}
