using UnityEngine;
using Enumerators;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Enumerators {

    public enum Colors { CYAN, YELLOW, MAGENTA, PINK };
}
public class GameManager : MonoBehaviour {
	

  //  [SerializeField] Rigidbody2D rigid_body_;
    //[SerializeField] SpriteRenderer sprite_renderer_;
    [SerializeField] Player playerCharacter;
    [SerializeField] GameObject PlayerObject;
    [SerializeField] Camera gameCamera;
    [SerializeField] GameObject[] checkpoints;

    private bool hasAlreadyDied = false;
    private int currentCheckPoint = 0;
    private int mScore = 0;



    // Use this for initialization
    void Start()
    {
        //ScoreManager[] scoreManagers = Resources.FindObjectsOfTypeAll<ScoreManager>();
        //Debug.Log(scoreManagers[0].ToString());
        //if (scoreManagers.Length > 0) 
        //    ScoreManager scoreManager = scoreManagers[0];

        // At start, choose a random color to the player:
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        checkOutOfBounds();
        checkCheckPoints();
    }

    private void checkCheckPoints(){
        if(checkpoints[currentCheckPoint].transform.position.y < playerCharacter.transform.position.y){
            SetRandomColor();
            currentCheckPoint++;
            UpdateScore();
        }
    }
    private void UpdateScore() {
        mScore += 100;
        GameObject scoreTextGameObject = GameObject.FindGameObjectWithTag("ScoreText");
        Text scoreText = scoreTextGameObject.GetComponent<Text>();
        scoreText.text = "SCORE: " + mScore;
    }
    private void checkOutOfBounds(){
        Vector3 screenPoint = gameCamera.WorldToViewportPoint(playerCharacter.transform.position);
        if(!(screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1))
        {
            if(!hasAlreadyDied){
                hasAlreadyDied = true;
            AudioSource sound = GetComponent<AudioSource>();
            sound.Play();
            mScore = 0;
            Invoke("loadDeathMenu", 1.5f);
            }
        }
    }

    public void InitDeathFlow() {
        SaveHighScore();
        loadDeathMenu();
    }

    private void loadDeathMenu() {
        hasAlreadyDied = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveHighScore() {
        // Get the current high score or zero incase of no record:
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentHighScore < mScore)
        {
            // In case the achived score is greater than the current high score:
            PlayerPrefs.SetInt("HighScore", mScore);
            Debug.Log("Updating high score from " + currentHighScore +
                "to " + mScore + ".");
        }
    }

    public void collided(ref Collider2D collision, Colors color){
        Debug.Log(collision.gameObject.tag.ToUpper() + " " + color.ToString());
        if (collision.gameObject.tag.ToUpper() != color.ToString())
        {
             if(!hasAlreadyDied){
                hasAlreadyDied = true;
            AudioSource sound = GetComponent<AudioSource>();
            sound.Play();
            GameObject.Find("Player").SetActive(false);
            Invoke("loadDeathMenu", 1.5f);
             }
        }
    }

    private void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        playerCharacter.setColor((Enumerators.Colors)index);
    }
 }
