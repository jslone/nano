using UnityEngine;
using System.Collections;

public enum Character {
	MICRO,
	NANO,
	PICO
};

public enum Controls {
	ARCADE,
	SMOOTH
};

[System.Serializable]
public struct CameraData {
	public CameraData(CameraData cam) {
		Track = cam.Track;
		Size = cam.Size;
		Offset = cam.Offset;
		Margin = cam.Margin;
		Smooth = cam.Smooth;
	}
	public Transform Track;
	public float Size;
	public Vector2 Offset;
	public Vector2 Margin;
	public Vector2 Smooth;
}

[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class PlayerController : MonoBehaviour {
	public Character Me;
	public Controls Type;

	// Movement attributes
	public float Speed;
	public float JumpSpeed;
	public float JumpSpeedDelay;
	public float JumpSpeedFalloff;

	// Movement capabilities
	public bool canMove;
	public bool canJump;

	public bool canCollide
	{
		get { return GetComponent<Collider2D>().enabled; }
		set
		{
			GetComponent<Collider2D>().enabled = value;
			Feet.GetComponent<Collider2D>().enabled = value;
			Debug.Log(Feet.GetComponent<Collider2D>().enabled);
		}
	}

	public Feet Feet;
	public bool isGrounded { get { return Feet.isGrounded; } }
	public bool isSwinging;

	// Movement vInput
	public Vector2 vInput;

	// Camera data for the CameraController
	public CameraData CameraData;

	// Trigger / Intractable layer
	public LayerMask TriggerLayer;
	public LayerMask DoorLayer;

	// Private variables
	private float lastJump;
	private Animator animator;
	new private Rigidbody2D rigidbody2D;	// rigidbody2D is marked as obsolete but not gone

	private bool facingRight = true;

	// Use this for initialization
	void Start () {

		// Initialize components
		vInput = Vector2.zero;
		animator = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();

		// Get stored location
		if(Me == Character.PICO) {
			transform.parent = GameObject.Find(Character.NANO.ToString()).transform;
			transform.localPosition = Vector3.right * 0.25f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)) {
			animator.SetTrigger("BossCutscene");
		}

		// update animator parameters
		animator.SetFloat("speed",canMove ? Mathf.Abs(vInput.x) : 0);
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	// Fixed update called every physics update
	void FixedUpdate() {
		if(canMove) {
			if((facingRight && vInput.x < 0) || (!facingRight && vInput.x > 0))
				Flip();

			Vector3 d = Type == Controls.ARCADE ? rigidbody2D.velocity : Vector2.zero;

			// Calculate run movement
			d.x = Speed * vInput.x;

			// Calculate jump movement
			if(vInput.y > 0) {
				if(canJump && (isGrounded || isSwinging) && Time.time - lastJump > JumpSpeedDelay) {
					d.y = JumpSpeed * vInput.y;
					lastJump = Time.time;
					isSwinging = false;
				} else if(Time.time - lastJump < JumpSpeedDelay) {
					d.y += JumpSpeed * JumpSpeedFalloff * vInput.y;
				}
			}

			// Apply movement
			if(Type == Controls.ARCADE) {
				rigidbody2D.velocity = d;
			} else {
				rigidbody2D.AddForce(d, ForceMode2D.Impulse);
			}
		}
	}

	// Do something with a trigger
	public void DoAction() {
		Collider2D col = Physics2D.OverlapPoint(transform.FindChild("Head").position,TriggerLayer);
		if(col) {
			col.GetComponent<Trigger>().OnTrigger();
		}
	}

	// Enter a door
	public void UseDoor() {
		Collider2D col = Physics2D.OverlapPoint(transform.FindChild("Head").position,DoorLayer);
		if(Me == Character.NANO && col) {
			canMove = false;
			col.GetComponent<LevelDoor>().EndScene();
		}
	}

	// Call an animation trigger
	public void SetTrigger(string trigger) {
		animator.SetTrigger(trigger);
	}

	// Switch the root animation on the animator
	public void FlipApplyRootMotion() {
		animator.applyRootMotion = !animator.applyRootMotion;
	}
}
