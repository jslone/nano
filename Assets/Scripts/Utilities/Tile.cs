using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Renderer))]
public class Tile : MonoBehaviour {
	public float scale = 5.0f;

	// Use this for initialization
	void Awake () {
		GetComponent<Renderer>().material.mainTextureScale = (new Vector2 (transform.localScale.x, transform.localScale.y))/scale;
		GetComponent<Renderer>().material.mainTexture.wrapMode = TextureWrapMode.Repeat;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
