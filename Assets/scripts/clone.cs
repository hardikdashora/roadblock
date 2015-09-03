using UnityEngine;
using System.Collections;

public class clone : MonoBehaviour {

	public GameObject truck;
	public Vector2 respawn_position;
	public float timer = 0.0f;
	public int counter = 0;
	int score = 0;
	
	public void respawn_truck()
	{
		respawn_position = new Vector2 (0, 6);
		var clone =  Instantiate (truck, respawn_position, Quaternion.identity);
		clone.name = "clone" + counter;

	}
	
	void OnGUI () 
	{
		GUI.color = Color.black;
		GUILayout.Label(" Score: " + score.ToString());
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
		
	{
		timer += Time.deltaTime;
		if (timer > 2) 
		{
			respawn_truck();
			timer = 0.0f;
			counter++;
			score++;
		}
	}


}
