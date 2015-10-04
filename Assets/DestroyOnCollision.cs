using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	public const string tagToDestroyAll = "any", tagToDestroyEnemy = "Enemy";
	public string tagToDestroy;

	// Use this for initialization
	void Start () {
		if (tagToDestroy == null) {
			tagToDestroy = tagToDestroyAll;		
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		print ("DestroyOnCollision::OnTriggerEnter2D() tag = " + col.gameObject.tag);
		if (tagToDestroy.Equals(tagToDestroyAll) || col.gameObject.CompareTag (tagToDestroy)) {

			Destroy(col.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		print ("DestroyOnCollision::OnCollisionEnter2D() tag = " + coll.gameObject.tag);
		if(coll.gameObject.CompareTag(tagToDestroyEnemy))
		{	
			ScoreManager.AddToScore();
			Destroy(coll.gameObject);
		}
	}
}
