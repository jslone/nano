using UnityEngine;
using System.Collections;

public enum Character {
	MICRO,
	NANO,
	PICO
};

[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class PlayerController : MonoBehaviour {
	private static int zoomLevel = 0;
	private static int microLevelDefault = 0;
	private static int nanoLevelDefault = 1;
	
	public Character Me;
	
	public float Speed;
	public float JumpSpeed;
	public float JumpSpeedDelay;
	public float JumpSpeedFalloff;
	
	public bool canMove;
	public bool canJump;
	
	public Feet Feet;
	public bool isGrounded { get { return Feet.isGrounded; } }
	
	public LayerMask TriggerLayer;
	
	private float lastJump;
	
	public Vector2 Input;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		Input = Vector2.zero;
		anim = GetComponent<Animator>();
		
		Vector3 pos = transform.position;
		switch(Me) {
			case Character.MICRO:
				pos.x = PlayerPrefs.GetFloat("micro.pos.x",transform.position.x);
				pos.y = PlayerPrefs.GetFloat("micro.pos.y",transform.position.y);
				break;
			case Character.NANO:
				pos.x = PlayerPrefs.GetFloat("nano.pos.x",transform.position.x);
				pos.y = PlayerPrefs.GetFloat("nano.pos.y",transform.position.y);
				break;
			case Character.PICO:
				break;
		}
		transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		// set animation
		anim.SetFloat("speed",Input.x);
	}
	
	// Fixed update called every physics update
	void FixedUpdate() {
		if(canMove) {
			Vector3 d = Vector2.zero;
			d.x = Speed * Input.x;
			d.y = canJump && isGrounded ? JumpSpeed * Input.y : 0;
			if(canJump && isGrounded) {
				d.y = JumpSpeed * Input.y;
				lastJump = Time.time;
			} else if(Time.time - lastJump < JumpSpeedDelay) {
				d.y = JumpSpeedFalloff * (JumpSpeed * Input.y);
			}
			
			rigidbody2D.AddForce(d, ForceMode2D.Impulse);
		}
	}
	
	public void DoAction() {
		Collider2D col = Physics2D.OverlapPoint(transform.position,TriggerLayer);
		if(col) {
			col.GetComponent<Trigger>().OnTrigger();
		}
	}
	
	public void ZoomIn() {
		switch(zoomLevel) {
			case 0:
				// load nano's world
				int level = PlayerPrefs.GetInt("nano.level",nanoLevelDefault);
				Application.LoadLevel(level);
				break;
			case 1:
				// switch to pico
				break;
			default:
				return;
		}
		zoomLevel++;
	}
	
	public void ZoomOut() {
		switch(zoomLevel) {
			case 1:
				// load micro's world
				int level = PlayerPrefs.GetInt("micro.level",microLevelDefault);
				Application.LoadLevel(level);
				break;
			case 2:
				// switch to nano
				break;
			default:
				return;
		}
		zoomLevel--;
	}
	
	void OnDestroy() {
		switch(Me) {
			case Character.MICRO:
				PlayerPrefs.SetFloat("micro.pos.x",transform.position.x);
				PlayerPrefs.SetFloat("micro.pos.y",transform.position.y);
				PlayerPrefs.SetInt("micro.level",Application.loadedLevel);
				break;
			case Character.NANO:
				PlayerPrefs.SetFloat("nano.pos.x",transform.position.x);
				PlayerPrefs.SetFloat("nano.pos.y",transform.position.y);
				PlayerPrefs.SetInt("nano.level",Application.loadedLevel);
				break;
			case Character.PICO:
				break;
		}
	}
}
