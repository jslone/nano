using UnityEngine;
using System.Collections;

public class PicoDeath : DeathController {
	public TogglePlayer toggle;
	public float TTL;

	// Use this for initialization
	void Start () {
		toggle = FindObjectOfType<TogglePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		TTL -= Time.deltaTime;
		if(TTL < 0) {
			Die ();
		}
	}

	public override void Die ()
	{
		toggle.ZoomOut();
		Destroy(gameObject);
	}
}
