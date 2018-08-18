using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {

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
