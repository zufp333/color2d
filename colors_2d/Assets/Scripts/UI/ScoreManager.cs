using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] int mCurrentHighScore = 0;
    [SerializeField] Text mCurrentHighScoreText;

    public void UpdateHighScore()
    {
        // Load current high score:
        mCurrentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        // Set it's text:
        GameObject highScoreTextGameObject = GameObject.FindGameObjectWithTag("HighScoreText");
        mCurrentHighScoreText.text = mCurrentHighScore.ToString();
    }
}
