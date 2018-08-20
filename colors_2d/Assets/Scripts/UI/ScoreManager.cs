using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField] int mCurrentHighScore = 0;
    [SerializeField] Text mCurrentHighScoreText;

    public void UpdateHighScore()
    {
        // Load current high score:
        mCurrentHighScore = PlayerPrefs.GetInt("HighScore", 0);

        GameObject highScoreTextGameObject = GameObject.FindGameObjectWithTag("HighScoreText");
       // Text highScoreText = highScoreTextGameObject.GetComponent<Text>();
        mCurrentHighScoreText.text = mCurrentHighScore.ToString();
    }
}
