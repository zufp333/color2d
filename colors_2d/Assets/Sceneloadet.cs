using UnityEngine.SceneManagement;
using UnityEngine;

public class Sceneloadet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		public void OnPlayButtonClicked()
    {
		Debug.Log("play button");
        // Load the next scene in the build qeue (scene "Level01")
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
			public void OnReturnButtonClicked()
    {
		Debug.Log("return button");
        // Load the next scene in the build qeue (scene "Level01")
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

	public void onCongratulateClicked(){
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
	}
}
