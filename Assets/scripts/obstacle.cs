using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	
	
	public Vector2 velocity = new Vector2(0, -4);
	public float range = 4;
	public float zIndex = 5f;
	
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = velocity;
		transform.position = new Vector3(transform.position.x, transform.position.y + range * Random.value, -0.1f);
		
		rigidbody2D.transform.localPosition = new Vector3(transform.position.x,
		                                                  transform.position.y,
		                                                  zIndex);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}