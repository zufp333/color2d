using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScores : MonoBehaviour {

	// Use this for initialization
	[SerializeField] Text scoretext;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void updateScores(int score){
        scoretext.text = "SCORE:\n" + score.ToString();
	}
}
