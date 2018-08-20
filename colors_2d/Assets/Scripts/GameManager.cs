using UnityEngine;
using Enumerators;
using UnityEngine.SceneManagement;
using System.Linq;

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
    [SerializeField] UpdateScores scoreText;
    [SerializeField] ScoreManager scoreManager;

    private bool hasAlreadyDied = false;
    private int currentChekPoint = 0;
    private int score = 0;



    // Use this for initialization
    void Start()
    {
        
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
        if(checkpoints[currentChekPoint].transform.position.y < playerCharacter.transform.position.y){
            Debug.Log("Checkpoont");
            SetRandomColor();
            currentChekPoint++;
            score+=100; 
            scoreText.updateScores(score);
            if(currentChekPoint == 3){
                
                congratulatePlayer();
                }
                 
        }
    }
    public void congratulatePlayer(){
                int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if(currentHighScore < score){
            Debug.Log("current high score:"+currentHighScore);
            Debug.Log("Current score:"+score);
            PlayerPrefs.SetInt("HighScore", score);}
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    private void checkOutOfBounds(){
        
        Vector3 screenPoint = gameCamera.WorldToViewportPoint(playerCharacter.transform.position);
        if(!(screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1))
        {
            Debug.Log("out of bounds");
            if(!hasAlreadyDied){
                hasAlreadyDied = true;
            AudioSource sound = GetComponent<AudioSource>();
            sound.Play();
            score = 0;
            Invoke("loadDeathMenu", 1.5f);
            }
        }
    }



    public void loadDeathMenu(){
        hasAlreadyDied = false;
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
                       Debug.Log("current high score:"+currentHighScore);
            Debug.Log("Current score:"+score);
        if(currentHighScore < score){
                Debug.Log("current high score:"+currentHighScore);
            Debug.Log("Current score:"+score);
            PlayerPrefs.SetInt("HighScore", score);
            }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
