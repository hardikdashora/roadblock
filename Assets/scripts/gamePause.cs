
using UnityEngine;
using System.Collections;

public class gamePause : MonoBehaviour {
	// Use this for initialization
	
	private float MouseDownPos; // down position
	private float MouseUpPos; // up position 


	void Start () {
	
	}

	
	// Update is called once per frame
	void Update () {
	

	}

	public void PauseGame()
	{
		print ("Pausing game");
		ObstacleSpawner.spawnObstacles = false;
	}
	

}
