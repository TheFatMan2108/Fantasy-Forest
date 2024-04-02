using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Move speed;
    [SerializeField] private TMP_Text textScore;
    [SerializeField] private TMP_Text textHighScore;
    private int tempScore ;
    private float scoreLevel;
    private RunAudio audioManager;
    int i;
    private void Awake()
    {
        
        textScore.SetText("Score " + tempScore.ToString("n0"));
        textHighScore.SetText("High Score " + gameManager.GetHighScore().ToString("n0"));
        scoreLevel = 1000;
    }
    private void Start()
    {
        audioManager = RunAudio.instance;
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        tempScore = gameManager.GetScore();
        if (collision.transform.CompareTag("Coin"))
        {
            tempScore += 20;
            tangTocTheoDiem();
            gameManager.SetScore(tempScore);
            gameManager.SetHighScore(tempScore);
            textScore.SetText("Score " + tempScore.ToString("n0"));
            textHighScore.SetText("High Score " + gameManager.GetHighScore().ToString("n0"));
            Destroy(collision.gameObject);
            if (audioManager==null)
            {
                return;
            }
            audioManager.PlaySound("Coin");
        }
    }

    private void tangTocTheoDiem()
    {
        float tempSpeed = speed.GetSpeed();
        if (tempScore>scoreLevel&&tempSpeed<=10)
        {
            scoreLevel += 1000;
            speed.SetSpeed((tempSpeed += 0.5f));
        }
    }
}
