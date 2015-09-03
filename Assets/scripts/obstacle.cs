using UnityEngine;
using System.Collections;

public class obstacle : MonoBehaviour {
	
	
	public Vector2 velocity = new Vector2(0, -4);
	public float range = 4;
	
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = velocity;
		transform.position = new Vector3(transform.position.x, transform.position.y + range * Random.value, -0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}