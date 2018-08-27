using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField] int mCurrentHighScore = 0;
    [SerializeField] Text mCurrentHighScoreText;

    public void UpdateHighScore()
    {
        mCurrentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        mCurrentHighScoreText.text = mCurrentHighScore.ToString();
    }
}
