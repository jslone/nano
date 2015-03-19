using UnityEngine;
using System.Collections;

public class VirusDeath : DeathController {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Die ()
	{
		Destroy(gameObject);
	}
}
