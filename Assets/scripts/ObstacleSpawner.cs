using UnityEngine;
using System.Collections;

public class ObstacleSpawner: MonoBehaviour {

	//public GameObject truck;
	//public GameObject blockLeft;
	public GameObject[] Myblocks = new GameObject[3];
	public Vector2 respawn_position;
	public float timer = 0.0f, spawnEvery = 1f; 
	public int counter = 0;
	int score = 0;

	public static bool spawnObstacles;

	public void DropObstacle()
	{
		print ("dropping obstacle");
		respawn_position = new Vector2 (0, 6);
		var clone = Instantiate (Myblocks[Random.Range(0,2)], respawn_position, Quaternion.identity);
		clone.name = "Obstacle_" + counter;

	}

	// Use this for initialization
	void Start () {
		spawnObstacles = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (spawnObstacles) 
		{
			timer += Time.deltaTime;
			if (timer > spawnEvery) 
			{
				timer = 0.0f;
				DropObstacle ();
				counter++;
			}
		}
	}


}
