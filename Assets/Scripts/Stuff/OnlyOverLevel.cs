using UnityEngine;
using System.Collections;

public class OnlyOverLevel : MonoBehaviour {
	public int level;
	// Use this for initialization
	void Start () {
		if(GameState.level <= level) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
