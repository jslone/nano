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
	
	public Feet Feet;
	public bool isGrounded { get { return Feet.isGrounded; } }

	// Movement Input
	public Vector2 Input;

	// Camera data for the CameraController
	public CameraData CameraData;

	// Trigger / Intractable layer
	public LayerMask TriggerLayer;

	// Private variables
	private float lastJump;
	private Animator animator;
	new private Rigidbody2D rigidbody2D;	// rigidbody2D is marked as obsolete but not gone

	private bool facingRight = true;

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
		animator.SetFloat("speed",Mathf.Abs(Input.x));
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
			if((facingRight && Input.x < 0) || (!facingRight && Input.x > 0))
				Flip();

			Vector3 d = Type == Controls.ARCADE ? rigidbody2D.velocity : Vector2.zero;

			// Calculate run movement
			d.x = Speed * Input.x;

			// Calculate jump movement
			if(Input.y > 0) {
				if(canJump && isGrounded && Time.time - lastJump > JumpSpeedDelay) {
					d.y = JumpSpeed * Input.y;
					lastJump = Time.time;
				} else if(Time.time - lastJump < JumpSpeedDelay) {
					d.y += JumpSpeed * JumpSpeedFalloff * Input.y;
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
		Collider2D col = Physics2D.OverlapPoint(transform.position,TriggerLayer);
		if(col) {
			col.GetComponent<Trigger>().OnTrigger();
		}
	}
}
