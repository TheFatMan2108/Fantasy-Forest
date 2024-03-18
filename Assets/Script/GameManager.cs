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
    private void Awake()
    {
        Score = 0;
        frameRate = 60;
        vollumMusic = PlayerPrefs.GetFloat(KEY_MUSIC,0.5f);
        vollumSound = PlayerPrefs.GetFloat(KEY_SOUND, 0.5f);
        highScore = PlayerPrefs.GetInt(KEY_HIGHSCORE, 0);
        Application.targetFrameRate = frameRate;
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
        PlayerPrefs.SetFloat (KEY_SOUND, vollumSound);
    }
    public void SetScore(int nScore)
    {
        Score = nScore;
    }
    public void SetHighScore(int nHighScore)
    {
        if (nHighScore>=highScore)
        {
            highScore = nHighScore;
            PlayerPrefs.SetInt(KEY_HIGHSCORE,highScore);
        }
    }
    public void SetPLaying(bool nPlaying)
    {
        isPlaying = nPlaying;
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
}
