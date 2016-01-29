using UnityEngine;
using System.Collections;

public class ParallaxPrefabSpawner : MonoBehaviour {

	public float downSpeed = 5f, spawnInterval = 1f;
	public GameObject[] prefabVariants;
	float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		time += Time.deltaTime;
		if (time >= spawnInterval) {
			time = 0;
			OnSpawnInterval();
		}

	}

	
	
	void OnSpawnInterval()
	{
		/*
		 * Function called once after every 'spawnInterval'
		 */
		try {
			/* Render random smoke object */
			GameObject randomObject = GetRandomPrefab ();
			Render(randomObject);
		} catch (System.Exception ex) {
			print (ex);
		} 
	}
	
	
	void Render(GameObject obj)
	{
		obj.transform.position = new Vector3 (GetSpawnCoordinateWithinRange( transform.position.x, transform.localScale.x), 
		                                      transform.position.y, 
		                                      transform.position.z);
		GameObject instantiatedObject = ((GameObject)GameObject.Instantiate (obj));
		instantiatedObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -1 * downSpeed);
	}

	float GetSpawnCoordinateWithinRange(float center, float width)
	{
		float result = 0f;
		result = Random.Range (center - width / 2, center + width / 2);
		return result;
		}
	
	GameObject GetRandomPrefab()
	{
		if (prefabVariants != null) {
			if(prefabVariants.Length != 0)
			{
				try {
					int randomNumber = (int)Random.Range(0f, prefabVariants.Length);
					return prefabVariants[randomNumber];
				} catch (System.Exception ex) {
					print (ex);
				}
			}
		}
		return null;
	}
}
