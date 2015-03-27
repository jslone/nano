using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	public static int level = 0;

	void Start()
	{

	}
	
	void Update ()
	{

	}

	public void Increment() {
		level++;
		Debug.Log(level);
	}

	public void LoadLevel(string level) {
		LevelDoor.lastSceneWasCutscene = true;
		Application.LoadLevel(level);
	}
	
}
