
using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour
{
    // Use this for initialization

    private float MouseDownPos; // down position
    private float MouseUpPos; // up position 
    public Canvas pauseMenu;            //Menu to show/hide on pause/resume
    public Canvas aboutMenu;            //Menu to show when user presses 'ABOUT'

    private float timeScale = 1f;
    private const float speedIncreaseFactor = 0.05f;
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ObstacleSpawner.spawnObstacles)
        {
            // If the game is running and the user presses back, pause the game
            print("GamePause::Update() Escape pressed");
            PauseGame();
        }
    }

    public static void StatPauseGame()
    {
        print("GamePause::StatPauseGame() Pausing game");
        Time.timeScale = 0f;
    }

    public static void StatResumeGame()
    {
        print("GamePause::StatResumeGame() Resuming game");
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {

        timeScale = Time.timeScale;
        if (pauseMenu != null)
        {
            print("GamePause::PauseGame() Pausing game");
            pauseMenu.enabled = true;
            Time.timeScale = 0f;
        }
    }

    public static void IncreaseSpeed()
    {

        /**
		 * Method multiplies global timescale with a speed multiplier
		 * that speeds up the game, increasing difficulty.
		 */

        Time.timeScale += speedIncreaseFactor;
        print("GamePause::IncreaseSpeed() timeScale is now " + Time.timeScale);
    }

    public void ResumeGame()
    {
        if (pauseMenu != null)
        {
            print("GamePause::ResumeGame() Resuming game");
            pauseMenu.enabled = false;
            Time.timeScale = timeScale;
        }
    }
    public void ShowAbout()
    {
        if (aboutMenu != null)
        {
            print("GamePause::ShowAbout() Showing about screen");
            Social.ReportProgress(RoadblockGPG.achievement_good_to_know_you, ScoreManager.GPG_PROGRESS_UNLOCK, (bool success) =>
            {
                print("GamePause::ShowAbout() Fire achievement 'Good To Know You' success = " + success);
            }
            );
            pauseMenu.enabled = false;
            aboutMenu.enabled = true;
        }
    }

    public void QuitGame()
    {
        if (pauseMenu != null)
        {
            print("GamePause::QuitGame() Ciao!");
            pauseMenu.enabled = false;
            Time.timeScale = 1f;
            Application.Quit();
        }
    }

}
