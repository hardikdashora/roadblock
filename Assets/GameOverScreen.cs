using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	public Text scoreDisplay, newHiScoreLabel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Show()
	{
		// Method to make the GameOver screen visible
		// score and hiscore display are done here only
		if (scoreDisplay != null) 
		{
			scoreDisplay.text = "" + ScoreManager.GetCurrentScore();
		}
		if (newHiScoreLabel != null)
		{
			if(ScoreManager.IsNewHiScore ()) 
			{
				newHiScoreLabel.enabled = true;
			} else 
			{
				newHiScoreLabel.enabled = false;
			}
		}
	}

	public void Dismiss()
	{
		// Mothod to hide the GameOverScreen
		enabled = false;
	}
}
