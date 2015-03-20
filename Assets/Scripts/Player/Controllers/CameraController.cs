using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	private PlayerController _player;
	private CameraData lastPlayerCamera;
	private Vector2 lastPlayerPos;
	public PlayerController player 		// Reference to the player's transform.
	{
		get
		{
			return _player;
		}
		set
		{
			if(_player == null) {
				camera.orthographicSize = value.CameraData.Size;
				offset = value.CameraData.Offset;
				margin = value.CameraData.Margin;
				smooth = value.CameraData.Smooth;
			} else {
				lastPlayerCamera = _player.CameraData;
				lastPlayerPos = _player.transform.position;
				lastPlayerChange = Time.time;
			}
			_player = value;
		}
	}
	public float changeSpeed;			// Rate at which camera changes players
    public Vector2 offset;              // Offset camera from center of player
	public Vector2 margin;				// Distance the player can move before the camera follows.
	public Vector2 smooth;				// How smoothly the camera catches up with its target movement.
    public Vector2 maxXAndY;			// The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY;			// The minimum x and y coordinates the camera can have.
	private Vector2 playerPos;			// Position of the player to track
	private float lastPlayerChange;		// Last time the player was changed
	new private Camera camera;			// Camera on this object

    bool CheckXMargin(Vector2 pos)
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.x - pos.x) > margin.x;
    }


    bool CheckYMargin(Vector2 pos)
    {
        // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
        return Mathf.Abs(transform.position.y - pos.y) > margin.y;
    }

	void Awake()
	{
		camera = GetComponent<Camera>();
	}

	void Update()
	{

	}

    void FixedUpdate()
    {
        TrackPlayer();
    }


    void TrackPlayer()
    {
		// Switch to new player
		if(lastPlayerChange > 0.0f)
		{
			camera.orthographicSize = Mathf.Lerp(lastPlayerCamera.Size, player.CameraData.Size, changeSpeed * (Time.time - lastPlayerChange));
			offset = Vector2.Lerp(lastPlayerCamera.Offset, player.CameraData.Offset, changeSpeed * (Time.time - lastPlayerChange));
			margin = Vector2.Lerp(lastPlayerCamera.Margin, player.CameraData.Margin, changeSpeed * (Time.time - lastPlayerChange));
			smooth = Vector2.Lerp(lastPlayerCamera.Smooth, player.CameraData.Smooth, changeSpeed * (Time.time - lastPlayerChange));
			playerPos = Vector2.Lerp(lastPlayerPos, player.transform.position, changeSpeed * (Time.time - lastPlayerChange));
		}
		// Update player position
		else
		{
			playerPos = player.transform.position;
		}

        // By default the target x and y coordinates of the camera are its current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        Vector2 track = playerPos + offset;
        // If the player has moved beyond the x margin...
        if (CheckXMargin(track))
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, track.x, smooth.x * Time.deltaTime);

        // If the player has moved beyond the y margin...
        if (CheckYMargin(track))
            // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
            targetY = Mathf.Lerp(transform.position.y, track.y, smooth.y * Time.deltaTime);

        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
