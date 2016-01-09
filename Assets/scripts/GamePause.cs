
using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {
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
		print ("GamePause::PauseGame() Pausing game");
		ObstacleSpawner.spawnObstacles = false;
	}
	

}
