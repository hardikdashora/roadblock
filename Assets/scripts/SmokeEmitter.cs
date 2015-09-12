using UnityEngine;
using System.Collections;

public class SmokeEmitter : MonoBehaviour {

	public float time = 0f, spawnInterval = 1f;
	public GameObject[] smokeVariants;

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
			GameObject randomObject = GetRandomSmoke ();
			RenderSprite(randomObject);
		} catch (System.Exception ex) {
			print (ex);
		} 
	}


	void RenderSprite(GameObject obj)
	{
		obj.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		GameObject.Instantiate (obj);
	}

	GameObject GetRandomSmoke()
	{
		if (smokeVariants != null) {
			if(smokeVariants.Length != 0)
			{
				try {
					int randomNumber = (int)Random.Range(0f, smokeVariants.Length);
					return smokeVariants[randomNumber];
				} catch (System.Exception ex) {
					print (ex);
				}
			}
		}
		return null;
	}
}