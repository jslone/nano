﻿using UnityEngine;
using System.Collections;

public class NanoDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.collider.tag == "Lava") {
			LevelDoor.lastSceneWasCutscene = false;
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
