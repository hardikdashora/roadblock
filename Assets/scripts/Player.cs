using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;

public class Player : MonoBehaviour {

	public Vector2 initialVelocity = new Vector2(0f,60f);
	public Vector2 initialposition = new Vector2(0f,-2.5f);
	public float zIndex = 5f;
	public float cutoffTimeInS = 3.0f;
	float timeInS = 0f;
	bool timerReached;
	public static string enemyTag = "Enemy";
	public AudioSource carStartSoundSource, crashSoundSource, bgmSoundSource;

	public Canvas gameOverScreen;
	public Button pauseButton;

	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody2D>().transform.position = initialposition;
		GetComponent<Rigidbody2D>().velocity = initialVelocity;
		
		GetComponent<Rigidbody2D>().transform.localPosition = new Vector3(initialposition.x,
		                                                  initialposition.y,
		                                                  zIndex);
		timeInS = 0f;
		timerReached = false;
		//Code to reset scores on every run. For testing purposes only!s
		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.Save ();

	}
	
	// Update is called once per frame
	void Update () {
		if (timerReached)
			return;
		timeInS += Time.deltaTime;
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, (initialVelocity.y * ((cutoffTimeInS - timeInS)/cutoffTimeInS))) ;

		if(timeInS % 1 == 0)
			print ("TimeInS = " + timeInS);

		if (timeInS >= cutoffTimeInS) {
			OnCutOffTimeReachedCallback();
		}
	}

	void OnCutOffTimeReachedCallback()
	{
		/**
		 * Called when the timer reaches the specified cut-off time
		 */

		//print ("Cutoff time reached");
		timerReached = true;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// print ("player.cs onEnterCollision2D()");
		if(col.gameObject.tag.Equals((enemyTag)))
		{
			print ("Player::OnCollisionEnter2D Hit enemy");
			Die ();
		}
		print ("Player::OnCollisionEnter2D(" + col.gameObject.name + ")");
	}

	public void Die()
	{
		if (gameOverScreen != null) {
			gameOverScreen.GetComponent<GameOverScreen>().Show();
			gameOverScreen.enabled = true;
		}
		TryToStopBGM();
		TryToPlayCrashSound();
		Time.timeScale = 0f;
		ObstacleSpawner.spawnObstacles = false;
		ScoreManager.StoreHiScore ();
	}
	
	public void Restart()
	{
		//To reload level 
		//Called when the car hits an obstacle
		Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		
	}

	private void TryToPlayCrashSound()
	{
		/**
		 * Method checks if crash-sound-source has
		 * been init. If yes, it plays the crash sound.
		 */

		if(crashSoundSource != null)
		{
			crashSoundSource.Stop();
			crashSoundSource.Play();
		}

	}
	
	private void TryToPlayStartSound()
	{
		/**
		 * Method checks if start-sound-source has
		 * been init. If yes, it plays the crash sound.
		 */
		
		if(carStartSoundSource != null)
		{
			carStartSoundSource.Stop();
			carStartSoundSource.Play();
		}
		
	}

	
	private void TryToStopBGM()
	{
		/**
		 * Method checks if the sound source for background
		 * music has been init. If yes, it stops the music.
		 */
		
		if(bgmSoundSource != null)
		{
			bgmSoundSource.Stop();
		}
		
	}
}
