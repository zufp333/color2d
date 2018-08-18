using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {

    private void Start()
    {
        ScoreManager scoreManagerScript = null;
        GameObject highScoreMenu = GameObject.FindGameObjectWithTag("HighScoreMenu");

        if (highScoreMenu != null)
            scoreManagerScript = highScoreMenu.GetComponent<ScoreManager>();
        else
            Debug.Log("highScoreMenu is null");

        if (scoreManagerScript != null)
            // Load the current high score:
            scoreManagerScript.UpdateHighScore();
        else
            Debug.Log("scoreManagerScript is null");
    }

    

    public void OnPlayButtonClicked()
    {
        // Load the next scene in the build qeue (scene "Level01")
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnOptionsButtonClick()
    {

    }

    public void OnExitButtonClicked()
    {
        // Quit the game:
        Application.Quit();
    }

}
