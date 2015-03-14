using UnityEngine;
using System.Collections;

public enum Character {
	MICRO,
	NANO,
	PICO
};

[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class PlayerController : MonoBehaviour {
	public Character Me;

	// Movement attributes
	public float Speed;
	public float JumpSpeed;
	public float JumpSpeedDelay;
	public float JumpSpeedFalloff;

	// Movement capabilities
	public bool canMove;
	public bool canJump;
	
	public Feet Feet;
	public bool isGrounded { get { return Feet.isGrounded; } }

	// Trigger / Intractable layer
	public LayerMask TriggerLayer;
	
	private float lastJump;
	
	public Vector2 Input;
	private Animator animator;
	new private Rigidbody2D rigidbody2D;	// rigidbody2D is marked as obsolete but not gone
	
	// Use this for initialization
	void Start () {

		// Initialize components
		Input = Vector2.zero;
		animator = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();

		// Get stored location
		if(Me == Character.PICO) {
			transform.parent = GameObject.Find(Character.NANO.ToString()).transform;
			transform.localPosition = Vector3.right;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// update animator parameters
		animator.SetFloat("speed",Input.x);
	}
	
	// Fixed update called every physics update
	void FixedUpdate() {
		if(canMove) {
			Vector3 d = Vector2.zero;

			// Calculate run movement
			d.x = Speed * Input.x;

			// Calculate jump movement
			if(canJump && isGrounded) {
				d.y = JumpSpeed * Input.y;
				lastJump = Time.time;
			} else if(Time.time - lastJump < JumpSpeedDelay) {
				d.y = JumpSpeedFalloff * (JumpSpeed * Input.y);
			}

			// Apply movement
			rigidbody2D.AddForce(d, ForceMode2D.Impulse);
		}
	}

	// Do something with a trigger
	public void DoAction() {
		Collider2D col = Physics2D.OverlapPoint(transform.position,TriggerLayer);
		if(col) {
			col.GetComponent<Trigger>().OnTrigger();
		}
	}
}
