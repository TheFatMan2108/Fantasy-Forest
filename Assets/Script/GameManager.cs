using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Score;
    private int highScore;
    private string KEY_HIGHSCORE = "HighScore";
    private void Awake()
    {
        Score = 0;
        highScore = PlayerPrefs.GetInt(KEY_HIGHSCORE, 0);
    }
    public int GetScore()
    {
        return Score;
    }
    public void SetScore(int nScore)
    {
        Score = nScore;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void SetHighScore(int nHighScore)
    {
        if (nHighScore>=highScore)
        {
            highScore = nHighScore;
            PlayerPrefs.SetInt(KEY_HIGHSCORE,highScore);
        }
    }
}
