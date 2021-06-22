using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;
    private int score;

    private void Update()
    {
        scoreText.text = "점수 : " + score;
        highScoreText.text = "최고점수 : " + PlayerPrefs.GetInt("score", 0);
    }

    public void GetScore()
    {
        score += 1;
    }
    
    public void ResetScore()
    {
        score = 0;
    }

    public void SaveData()
    {
        if (score > PlayerPrefs.GetInt("score", 0))
            PlayerPrefs.SetInt("score", score);
    }
}
