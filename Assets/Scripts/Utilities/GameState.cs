using UnityEngine;
using UnityEngine.SceneManagement;
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
	}

	public static void SetLevel(int newLevel) {
		level = Mathf.Max(level, newLevel);
	}

	public void SetLevelAnim(int newLevel) {
		level = Mathf.Max(level, newLevel);
	}

	public void LoadLevel(string level) {
		LevelDoor.lastSceneWasCutscene = true;
		SceneManager.LoadScene(level);
	}

}
