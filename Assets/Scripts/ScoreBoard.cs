using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ScoreBoard : MonoBehaviour
{   int score;
    TMP_Text scoreText;
    String scoreString;
    void Start() 
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text= "Score: 0";
    }
     
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text ="Score: " + score.ToString();
    }
}
