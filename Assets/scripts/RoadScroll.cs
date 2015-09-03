using UnityEngine;
using System.Collections;

public class RoadScroll : MonoBehaviour {
	
	public float speed = 0.5f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 offset = new Vector2 (0, speed * Time.time);
		
		renderer.material.mainTextureOffset = offset;
		
	}
}