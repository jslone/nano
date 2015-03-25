using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PicoDeath : DeathController {
	public TogglePlayer toggle;
	public float TTL;
	public float DeathSpeed;
	private float TTD;
	private Vector3 deathPos;
	private float timeOfDeath;
	public bool dead;
	public Text timer;

	// Use this for initialization
	void Start () {
		toggle = FindObjectOfType<TogglePlayer>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 localScale = timer.rectTransform.localScale;
		localScale.x = Mathf.Sign(transform.lossyScale.x) * Mathf.Abs(localScale.x);
		timer.rectTransform.localScale = localScale;


		TTL -= Time.deltaTime;
		timer.text = dead ? "" : TTL.ToString("F1");
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
		TTD = (transform.parent.position - transform.position).magnitude / DeathSpeed;
		GetComponent<Collider2D>().enabled = false;
	}
}
