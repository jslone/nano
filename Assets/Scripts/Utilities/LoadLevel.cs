﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider2D))]
public class LoadLevel : MonoBehaviour {
	public string level;
	private bool hasLoaded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!hasLoaded) {
			Application.LoadLevelAdditive(level);
			hasLoaded = true;
			Destroy(this);
		}
	}
}