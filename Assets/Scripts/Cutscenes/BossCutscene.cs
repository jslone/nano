using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossCutscene : MonoBehaviour {
	public PlayerController player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Flip() {
		player.Flip();
	}

	public void LoadBossLevel() {
		LevelDoor.lastSceneWasCutscene = true;
		SceneManager.LoadScene("nanoBoss");
	}
}
