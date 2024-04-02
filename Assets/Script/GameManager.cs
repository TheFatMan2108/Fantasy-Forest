using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Score;
    private int highScore;
    private float vollumMusic;
    private float vollumSound;
    private int frameRate;
    private bool isPlaying = false;
    private string KEY_HIGHSCORE = "HighScore";
    private string KEY_MUSIC = "music";
    private string KEY_SOUND = "sound";
    private int statusSeasion = 0;
    private List<Color> colors;
    private int nextScore;
    private float heart;
    private float heartMax;
    private float heartMin;
    private float timeCountMax;
    private float timeCountMin;
    private void Awake()
    {
        heartMin =0f;
        heartMax = 5f;
        timeCountMax = 3;
        timeCountMin = 0;
        heart = heartMax;
        colors = new List<Color>();
        nextScore = 0;
        AddCollor();
        Score = 0;
        frameRate = 60;
        vollumMusic = PlayerPrefs.GetFloat(KEY_MUSIC, 0.5f);
        vollumSound = PlayerPrefs.GetFloat(KEY_SOUND, 0.5f);
        highScore = PlayerPrefs.GetInt(KEY_HIGHSCORE, 0);
        Application.targetFrameRate = frameRate;
    }
    private void Update()
    {
        if (Score>=nextScore)
        {
            nextScore += 1000;
            statusSeasion++;
        }
    }
    private void AddCollor()
    {
        colors.Add(new Color(255, 0, 127));// color spring
        colors.Add(new Color(255, 255, 255));// color summer
        colors.Add(new Color(255, 93, 0));//Color autumn
        colors.Add(new Color(0, 151, 255));//Color winter
    }

    // SET
    public void SetFrameRate(float nFrameRate)
    {
        frameRate = int.Parse(nFrameRate.ToString());
        Application.targetFrameRate = frameRate;
    }
    public void SetMusic(float nMusic)
    {
        vollumMusic = nMusic;
        PlayerPrefs.SetFloat(KEY_MUSIC, vollumMusic);
    }
    public void SetSound(float nSound)
    {
        vollumSound = nSound;
        PlayerPrefs.SetFloat(KEY_SOUND, vollumSound);
    }
    public void SetScore(int nScore)
    {
        Score = nScore;
    }
    public void SetHighScore(int nHighScore)
    {
        if (nHighScore >= highScore)
        {
            highScore = nHighScore;
            PlayerPrefs.SetInt(KEY_HIGHSCORE, highScore);
        }
    }
    public void SetPLaying(bool nPlaying)
    {
        isPlaying = nPlaying;
    }
    public void SetStatusSeasion(ref int i)
    {
        if (i < 4)
        {
            statusSeasion = i;
        }
        else
        {
            statusSeasion = 0;
        }
    }
    public void SetHeart(float nHeart)
    {
        heart = nHeart;
    }
    public void SetHeartMax(float nHeartMax)
    {
        heartMax = nHeartMax;
    }
    public void SetHeartMin(float nHeartMin)
    {
        heartMin = nHeartMin;
    }
    public void SetTimeCountMax(float nTimeMax)
    {
        timeCountMax = nTimeMax;
    }
    public void SetTimeCountMin(float nTimeMin)
    {
        timeCountMin = nTimeMin;
    }
    // GET
    public float GetMusicVollum()
    {
        return vollumMusic;
    }
    public float GetSoundVollum()
    {
        return vollumSound;
    }
    public int GetHighScore()
    {
        return highScore;
    }
    public int GetScore()
    {
        return Score;
    }
    public bool GetPlaying()
    {
        return isPlaying;
    }
    public Color GetColor(int indexColor)
    {
        int i = indexColor-1;
        if (i >= 0)
        {
            return colors[i];
        }
        else
        {
            return colors[0];
        }

    }
    public int GetStatusSeasion()
    {
        return statusSeasion;
    }
    public float GetHeart()
    {
        return heart;
    }
    public float GetMaxHeart()
    {
        return heartMax;
    }
    public float GetMinHeart()
    {
        return heartMin;
    }
    public float GetTimCountMax()
    {
        return timeCountMax;
    }
    public float GetTimCountMin()
    {
        return timeCountMin;
    }
}
