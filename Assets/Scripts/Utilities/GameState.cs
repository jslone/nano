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

	public static void SetLevel(int newLevel) {
		level = Mathf.Max(level, newLevel);
		Debug.Log(level);
	}

	public void SetLevelAnim(int newLevel) {
		level = Mathf.Max(level, newLevel);
		Debug.Log(level);
	}

	public void LoadLevel(string level) {
		LevelDoor.lastSceneWasCutscene = true;
		Application.LoadLevel(level);
	}
	
}
