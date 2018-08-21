using UnityEngine;
using Enumerators;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Enumerators
{

    public enum Colors { CYAN, YELLOW, MAGENTA, PINK };
}
public class GameManager : MonoBehaviour
{

    [SerializeField] Player mPlayerCharacter;
    [SerializeField] Camera mGameCamera;
    [SerializeField] GameObject[] mCheckpoints;
    [SerializeField] Text scoreText;

    private bool mHasAlreadyDied = false;
    private int mCurrentCheckPoint = 0;
    private int mScore = 0;



    // Use this for initialization
    void Start()
    {
        // At start, choose a random color to the player:
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOutOfBounds();
        CheckCheckPoints();
    }

    private void CheckCheckPoints()
    {
        if (mCheckpoints[mCurrentCheckPoint].transform.position.y <= mPlayerCharacter.transform.position.y)
        {
            Debug.Log("Checkpoint");

            SetRandomColor();
            mCurrentCheckPoint++;
            mScore += 100;
            UpdateScores(mScore);

            if (mCurrentCheckPoint == 3)
            {

                CongratulatePlayer();
            }
        }
    }

    public void CongratulatePlayer()
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentHighScore < mScore)
        {
            Debug.Log("current high score:" + currentHighScore);
            Debug.Log("Current score:" + mScore);

            PlayerPrefs.SetInt("HighScore", mScore);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    private void CheckOutOfBounds()
    {
        Vector3 screenPoint = mGameCamera.WorldToViewportPoint(mPlayerCharacter.transform.position);

        if (!(screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1))
        {
            Debug.Log("out of bounds");

            if (!mHasAlreadyDied)
            {
                mHasAlreadyDied = true;
                AudioSource sound = GetComponent<AudioSource>();
                sound.Play();
                mScore = 0;
                Invoke("loadDeathMenu", 1.5f);
            }
        }
    }

    public void LoadDeathMenu()
    {
        mHasAlreadyDied = false;
        Debug.Log(" DIED ");
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

        Debug.Log("current high score:" + currentHighScore);
        Debug.Log("Current score:" + mScore);

        if (currentHighScore < mScore)
        {
            Debug.Log("current high score:" + currentHighScore);
            Debug.Log("Current score:" + mScore);
            PlayerPrefs.SetInt("HighScore", mScore);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnCollisionFlow(ref Collider2D collision, Colors color)
    {
        Debug.Log(collision.gameObject.tag.ToUpper() + " " + color.ToString());

        if (collision.gameObject.tag.ToUpper() != color.ToString())
        {
            if (!mHasAlreadyDied)
            {
                mHasAlreadyDied = true;
                AudioSource sound = GetComponent<AudioSource>();
                sound.Play();
                GameObject.Find("Player").SetActive(false);
                Invoke("loadDeathMenu", 1.5f);
            }
        }
    }

    private void UpdateScores(int score)
    {
        scoreText.text = "SCORE:\n" + score.ToString();
    }


    private void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        mPlayerCharacter.SetColor((Enumerators.Colors)index);
    }
}