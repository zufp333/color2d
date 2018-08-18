using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text currentHighScoreText_;
    [SerializeField] int currentHighScore_ = 0;

    public void UpdateHighScore(int currentGameScore)
    {
        // This function is called at the end of each game.
        int scoreToSet = (currentGameScore > currentHighScore_) ? currentGameScore : currentHighScore_;
        currentHighScoreText_.text = scoreToSet.ToString();
    }
}
