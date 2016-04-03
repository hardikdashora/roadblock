using UnityEngine;
using System.Collections;

public class TapToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSpawningObstacles()
	{
		// Indicates tap on the start screen
		// Game to be started when this happens

		print ("Let's begin!");
		ObstacleSpawner.spawnObstacles = true;
		Destroy (gameObject);
	}
}
